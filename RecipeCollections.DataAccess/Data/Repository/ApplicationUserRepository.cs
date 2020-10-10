using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository{

        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
