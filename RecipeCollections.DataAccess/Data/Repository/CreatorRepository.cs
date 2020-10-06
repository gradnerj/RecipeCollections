using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class CreatorRepository : Repository<Creator>, ICreatorRepository {
        private readonly ApplicationDbContext _context;

        public CreatorRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCreatorList() {
            throw new System.NotImplementedException();
        }


        public void Update(Creator creator) {
            throw new System.NotImplementedException();
        }
    }
}
