using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.Models;

namespace RecipeCollections.Pages.Creator
{
    public class IndexModel : PageModel
    {
        private readonly RecipeCollections.Data.ApplicationDbContext _context;

        public IndexModel(RecipeCollections.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.ToListAsync();
        }
    }
}
