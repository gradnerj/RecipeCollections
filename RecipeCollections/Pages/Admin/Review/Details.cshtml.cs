using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.Models;

namespace RecipeCollections.Pages.Admin.Review
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeCollections.Data.ApplicationDbContext _context;

        public DetailsModel(RecipeCollections.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews.FirstOrDefaultAsync(m => m.Id == id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
