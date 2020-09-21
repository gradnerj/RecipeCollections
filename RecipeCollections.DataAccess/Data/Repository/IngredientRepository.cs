using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
