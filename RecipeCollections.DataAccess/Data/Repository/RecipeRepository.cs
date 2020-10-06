using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetRecipeList() {
            throw new System.NotImplementedException();
        }

        public void Update(Recipe recipe) {
            throw new System.NotImplementedException();
        }
    }
}
