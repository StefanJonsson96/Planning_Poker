// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningPoker.Domain;
using PlanningPoker.Persistence;

namespace PlanningPoker.Areas.Identity.Pages.Account.Manage
{
    public class EditModel : PageModel
    {
        private readonly UserManager<PlanningPokerUser> _userManager;
        private readonly SignInManager<PlanningPokerUser> _signInManager;
        private readonly PlanningPokerDbContext _context;
        public List<Team> _team;
        public string _oldpic;
        public string _oldteam;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModel(
            UserManager<PlanningPokerUser> userManager,
            SignInManager<PlanningPokerUser> signInManager,
            PlanningPokerDbContext context, 
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _team = _context.Team.ToList();
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [PersonalData]
            [Display(Name = "Full Name")]
            public string? Name { get; set; }

            [Required]
            [PersonalData]
            [Display(Name = "Date of birth")]
            public DateTime DOB { get; set; }

            
            public string TeamName { get; set; }

            public int TeamId { get; set; }

            public IFormFile ImageFile { get; set; }

        }

        private async Task LoadAsync(PlanningPokerUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var fullName = user.Name;
            var DOB = user.DOB;
            var teamId = user.TeamId;
            var teams = _context.Team
                                .ToList();
            var team = _context.Team
                               .Where(t => t.Id == teamId)
                               .FirstOrDefault();

            var teamName = team.Name;
            _oldpic = user.ImagePath;
            _oldteam = team.Name;
            

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Name = fullName,
                DOB = DOB,
                TeamId = teamId,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);           
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            
            if (Input.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = Input.PhoneNumber;
            }
            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
            }
            if (Input.DOB != user.DOB)
            {
                user.DOB = Input.DOB;
            }
            var team = _context.Team
                               .Where(t => t.Name == Input.TeamName)
                               .FirstOrDefault();

            var teamOld = _context.Team
                                  .Where(t => t.Id == user.TeamId)
                                  .FirstOrDefault();

            var teamName = teamOld.Name;
            if (Input.TeamName != teamName && Input.TeamName != null)
            {
                user.TeamId = team.Id;
            }
            if (Input.ImageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(Input.ImageFile.FileName);
                string extension = Path.GetExtension(Input.ImageFile.FileName);

                fileName = user.Id + extension; //name it after the UserId

                string path = Path.Combine(wwwRootPath + "/Images/Users/", fileName);


                //Remove old file
                if (System.IO.File.Exists(Path.Combine(wwwRootPath, user.ImagePath)))
                {
                    System.IO.File.Delete(Path.Combine(wwwRootPath, user.ImagePath));
                }

                //Save file
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Input.ImageFile.CopyToAsync(fileStream);
                }

                //Update imagepath 
                user.ImagePath = Path.Combine("/Images/Users/", fileName);
            }
            user.Updated = DateTime.Now;
            _context.Update(user);
            await _context.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
            //StatusMessage = "Your profile has been updated";
            //return RedirectToPage("Account/Profile");
            return Redirect("../Profile");
        }
    }
}
