using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class ReviewRepository : Repository<Review>, IReviewRepository {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context){
            _context = context;
        }
    }
}
