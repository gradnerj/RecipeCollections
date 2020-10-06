using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class UtensilRepository : Repository<Utensil>, IUntensilRepository {
        private readonly ApplicationDbContext _context;

        public UtensilRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetUtensilList() {
            throw new System.NotImplementedException();
        }

        public void Update(Utensil utensil) {
            throw new System.NotImplementedException();
        }
    }
}
