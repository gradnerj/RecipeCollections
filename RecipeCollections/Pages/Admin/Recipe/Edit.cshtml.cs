using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.DataAccess.Data.Repository.IRepository;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUnitOfWork unitOfWork)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Recipe Recipe { get; set; }
        [BindProperty]
        public string OldPhotoPath { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Recipe = _unitOfWork.Recipe.GetFirstorDefault(m => m.Id == id, "Category");

            if (Recipe == null) {
                return NotFound();
            }
            CategoryList = _unitOfWork.Category.GetCategoryListForDropDown();
            
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
