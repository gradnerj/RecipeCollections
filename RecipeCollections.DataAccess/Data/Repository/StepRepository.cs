using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class StepRepository : Repository<Step>, IStepRepository {
        private readonly ApplicationDbContext _context;

        public StepRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }
    }
}
