using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;


namespace RecipeCollections.DataAccess.Data.Repository {
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetIngredientList() {
            throw new System.NotImplementedException();
        }

        public void Update(Ingredient ingredient) {
            throw new System.NotImplementedException();
        }
    }
}
