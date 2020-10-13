using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class UnitOfWork : IUnitOfWork {

        private readonly ApplicationDbContext _context;

        public IRecipeRepository Recipe { get; private set; }

  

        public IReviewRepository Review { get; private set; }


        public IApplicationUserRepository ApplicationUser { get; private set; }

        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            Recipe = new RecipeRepository(_context);
            Review = new ReviewRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            Category = new CategoryRespository(_context);
        }
        public void Dispose() {
            _context.Dispose();
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
