using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class EditModel : RecipeCategoriesPageModel
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
        //public IEnumerable<SelectListItem> CategoryList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Recipe = await  _context.Recipes
                .Include(r => r.RecipeCategories)
                    .ThenInclude(r => r.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null) {
                return NotFound();
            }
            //CategoryList = _unitOfWork.Category.GetCategoryListForDropDown();
            PopulateRecipeCategories(_context, Recipe);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var recipeToUpdate = await _context.Recipes
                .Include(r => r.RecipeCategories)
                    .ThenInclude(r => r.Category).FirstOrDefaultAsync(c => c.Id == id);
            
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
                recipeToUpdate.PhotoPath = @"\images\recipe_photos\" + fileName + extension;
            }
            else if(OldPhotoPath != null) {
                recipeToUpdate.PhotoPath = OldPhotoPath;
            }

            // _context.Attach(Recipe).State = EntityState.Modified;
            if (await TryUpdateModelAsync<Models.Recipe>(
                 recipeToUpdate,
                 "Recipe",
                 r => r.Title, r => r.PrepTime,
                 r => r.CookTime, r=>r.FeedsQty, 
                 r => r.Instructions)) {

                UpdateRecipeCategories(_context, selectedCategories, recipeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


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
