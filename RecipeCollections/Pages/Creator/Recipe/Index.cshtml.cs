using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.Models.Models.RecipeViewModels;

namespace RecipeCollections.Pages.Creator {
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
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

            Recipe = await _context.Recipes.Include(r => r.RecipeCategories)
                    .ThenInclude(r => r.Category).Where(r => r.CreatorId == id).ToListAsync();
                   
                    
        }
    }
}
