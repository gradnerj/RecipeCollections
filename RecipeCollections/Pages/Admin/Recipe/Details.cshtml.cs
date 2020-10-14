using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models.Models.RecipeViewModels;
using System.Linq;
using System.Threading.Tasks;

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

        [BindProperty]
        public Models.Recipe Recipe { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }
            Recipe = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .ThenInclude(r=>r.Category)
                .SingleAsync(r => r.Id == id);

            if (Recipe == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
