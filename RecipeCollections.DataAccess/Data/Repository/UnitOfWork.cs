using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class UnitOfWork : IUnitOfWork {

        private readonly ApplicationDbContext _context;
        public ICreatorRepository Creator { get; private set; }

        public IRecipeRepository Recipe { get; private set; }

        public IIngredientRepository Ingredient { get; private set; }

        public IReviewRepository Review { get; private set; }

        public IStepRepository Step { get; private set; }

        public IUntensilRepository Utensil { get; private set; }

        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            Creator = new CreatorRepository(_context);
            Recipe = new RecipeRepository(_context);
            Ingredient = new IngredientRepository(_context);
            Review = new ReviewRepository(_context);
            Step = new StepRepository(_context);
            Utensil = new UtensilRepository(_context);

        }
        public void Dispose() {
            _context.Dispose();
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
