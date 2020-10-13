using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        [BindProperty]
        public IList<Models.Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var id = claim.Value;
            Recipe = await _context.Recipes.Where(r => r.CreatorId == id).ToListAsync();
        }
    }
}
