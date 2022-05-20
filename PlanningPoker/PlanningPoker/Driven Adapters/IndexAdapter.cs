using Microsoft.AspNetCore.Components;
using PlanningPoker.Persistence;

namespace PlanningPoker.Driven_Adapters
{
    public class IndexAdapter : IIndexAdapter
    {
        private readonly PlanningPokerDbContext _context;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityContext _identityContext;

        public IndexAdapter(PlanningPokerDbContext context, NavigationManager navigationManager, IdentityContext identityContext)
        {
            _context = context;
            _navigationManager = navigationManager;
            _identityContext = identityContext;
            //_context.Database.EnsureCreated();
            //_identityContext.Database.EnsureCreated();
        }
    }
}
