using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class UtensilRepository : Repository<Utensil>, IUntensilRepository {
        private readonly ApplicationDbContext _context;

        public UtensilRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
