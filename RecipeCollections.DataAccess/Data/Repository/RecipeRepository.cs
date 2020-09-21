using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
