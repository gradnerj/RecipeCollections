using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class UnitOfWork : IUnitOfWork {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
        }
        public void Dispose() {
            _context.Dispose();
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
