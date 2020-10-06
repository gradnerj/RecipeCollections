using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class ReviewRepository : Repository<Review>, IReviewRepository {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context){
            _context = context;
        }

        public IEnumerable<SelectListItem> GetReviewList() {
            throw new System.NotImplementedException();
        }

        public void Update(Review review) {
            throw new System.NotImplementedException();
        }
    }
}
