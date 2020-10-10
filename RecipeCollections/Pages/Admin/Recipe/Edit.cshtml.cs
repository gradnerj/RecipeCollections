using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EditModel(Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public Models.Recipe Recipe { get; set; }
        [BindProperty]
        public string OldPhotoPath { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

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
                if (OldPhotoPath != null) {
                    var imgPath = Path.Combine(_hostEnvironment.WebRootPath, OldPhotoPath.TrimStart('\\'));
                    if (System.IO.File.Exists(imgPath)) {
                        System.IO.File.Delete(imgPath);
                    }
                }
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\recipe_photos\");
                var extension = Path.GetExtension(files[0].FileName);
                var fullpath = uploads + fileName + extension;
                using (var fileStream = System.IO.File.Create(fullpath)) {
                    files[0].CopyTo(fileStream);
                }
                Recipe.PhotoPath = @"\images\recipe_photos\" + fileName + extension;
            }
            else if(OldPhotoPath != null) {
                Recipe.PhotoPath = OldPhotoPath;
            }

            _context.Attach(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
