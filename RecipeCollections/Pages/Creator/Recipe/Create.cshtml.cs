using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using RecipeCollections.Pages.Admin.Recipe;

namespace RecipeCollections.Pages.Creator
{
    public class CreateModel : RecipeCategoriesPageModel
    {
        private readonly RecipeCollections.Data.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CreateModel(RecipeCollections.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUnitOfWork unitOfWork)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
            _unitofWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            var recipe = new Models.Recipe();
            recipe.RecipeCategories = new List<RecipeCategory>();
            PopulateRecipeCategories(_context, recipe);


            return Page();
        }

        [BindProperty]
        public Models.Recipe Recipe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (selectedCategories != null) {
                Recipe.RecipeCategories = new List<RecipeCategory>();
                foreach (var cat in selectedCategories) {
                    var catToAdd = new RecipeCategory {
                        CategoryId = int.Parse(cat)
                    };
                    Recipe.RecipeCategories.Add(catToAdd);
                }
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

                System.IO.File.Copy(defaults[0], fullpath);

                Recipe.PhotoPath = @"\images\recipe_photos\" + fileName + extension;
            }
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
