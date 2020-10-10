using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CreateModel(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Recipe Recipe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0) {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\recipe_photos\");
                var extension = Path.GetExtension(files[0].FileName);
                var fullpath = uploads + fileName + extension;
                using (var fileStream = System.IO.File.Create(fullpath)) {
                    files[0].CopyTo(fileStream);
                }
                Recipe.PhotoPath = @"\images\recipe_photos\" + fileName + extension;
            } else {
                
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\recipe_photos\");
                var extension = Path.GetExtension(@"images\defaults\DefaultImage.jpg");
                var fullpath = uploads + fileName + extension;
                var defaults = Directory.GetFiles(Path.Combine(webRootPath, @"images\defaults\"));
               
                System.IO.File.Copy(defaults[0],fullpath);
                
                Recipe.PhotoPath = @"\images\recipe_photos\" + fileName + extension;
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
