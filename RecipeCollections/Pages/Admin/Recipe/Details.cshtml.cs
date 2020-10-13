using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;

namespace RecipeCollections.Pages.Admin.Recipe
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeCollections.Data.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(RecipeCollections.Data.ApplicationDbContext context, IUnitOfWork unitOfWork)
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
