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

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Recipe = _unitOfWork.Recipe.GetFirstorDefault(m => m.Id == id, "Category");

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
            Recipe = await _context.Recipes.FindAsync(id);
            if (Recipe.PhotoPath != null) {
                var imgPath = Path.Combine(_hostEnvironment.WebRootPath, Recipe.PhotoPath.TrimStart('\\'));
                if (System.IO.File.Exists(imgPath)) {
                    System.IO.File.Delete(imgPath);
                }
            }
            if (Recipe != null)
            {
                _context.Recipes.Remove(Recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
