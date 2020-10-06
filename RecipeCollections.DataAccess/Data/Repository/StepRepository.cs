using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class StepRepository : Repository<Step>, IStepRepository {
        private readonly ApplicationDbContext _context;

        public StepRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetStepList() {
            throw new System.NotImplementedException();
        }

        public void Update(Step step) {
            throw new System.NotImplementedException();
        }
    }
}
