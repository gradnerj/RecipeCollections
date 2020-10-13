using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(Data.ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public Models.Recipe Recipe { get; set; }

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Recipe = _unitOfWork.Recipe.GetFirstorDefault(m => m.Id == id,  "Category");

            if (Recipe == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
