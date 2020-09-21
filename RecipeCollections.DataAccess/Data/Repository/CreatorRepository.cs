using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class CreatorRepository : Repository<Creator>, ICreatorRepository {
        private readonly ApplicationDbContext _context;

        public CreatorRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
