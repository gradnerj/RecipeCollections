using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;

namespace RecipeCollections.Pages.Admin.Review {
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Review> Review { get;set; }

        public async Task OnGetAsync()
        {
            Review = await _context.Reviews.ToListAsync();
        }
    }
}
