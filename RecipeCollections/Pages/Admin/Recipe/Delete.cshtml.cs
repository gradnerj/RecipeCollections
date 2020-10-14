using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUnitOfWork unitOfWork)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Recipe Recipe { get; set; }
       
        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Recipe = await _context.Recipes.Include(r => r.RecipeCategories)
                .ThenInclude(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Models.Recipe recipeToDelete = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .SingleAsync(r => r.Id == id);

            if (recipeToDelete.PhotoPath != null) {
                var imgPath = Path.Combine(_hostEnvironment.WebRootPath, recipeToDelete.PhotoPath.TrimStart('\\'));
                if (System.IO.File.Exists(imgPath)) {
                    System.IO.File.Delete(imgPath);
                }
            }
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
