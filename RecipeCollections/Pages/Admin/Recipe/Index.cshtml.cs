using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Utility;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public string TitleSort { get; set; }
        public string CategorySort { get; set; }
        public string PrepTimeSort { get; set; }
        public string CookTimeSort { get; set; }
        public string FeedsQtySort { get; set; }
        public string CreatorIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Models.Recipe> Recipes { get;set; }

        public async Task OnGetAsync(string sortType, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortType;
            TitleSort = String.IsNullOrEmpty(sortType) ? "title_desc" : "";
            CategorySort = sortType == "Category" ? "category_desc" : "Category";
            PrepTimeSort = sortType == "PrepTime" ? "preptime_desc" : "PrepTime";
            CookTimeSort = sortType == "CookTime" ? "cooktime_desc" : "CookTime";
            FeedsQtySort = sortType == "FeedsQty" ? "feedsqty_desc" : "FeedsQty";
            CreatorIdSort = sortType == "CreatorID" ? "creatorid_desc" : "CreatorID";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            var recipesIQ = getFilteredSorted(sortType, CurrentFilter);
            int pageSize = 3;
            Recipes = await PaginatedList<Models.Recipe>.CreateAsync(recipesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        private IQueryable<Models.Recipe> getFilteredSorted(string sortType, string filterBy) {
            IQueryable<Models.Recipe> recipesIQ = _unitOfWork.Recipe.GetAll(null, null,"Category");

            if (!String.IsNullOrEmpty(filterBy)) {
                recipesIQ = recipesIQ.Where(r => r.Title.Contains(filterBy) || r.Category.Name.Contains(filterBy));
            }
            switch (sortType) {
                case "title_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.Title);
                    return recipesIQ;
                case "category_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.Category.Name);
                    return recipesIQ;
                case "Category":
                    recipesIQ = recipesIQ.OrderBy(r => r.Category.Name);
                    return recipesIQ;
                case "preptime_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.PrepTime);
                    return recipesIQ;
                case "PrepTime":
                    recipesIQ = recipesIQ.OrderBy(r => r.PrepTime);
                    return recipesIQ;
                case "cooktime_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.CookTime);
                    return recipesIQ;
                case "CookTime":
                    recipesIQ = recipesIQ.OrderBy(r => r.CookTime);
                    return recipesIQ;
                case "feedsqty_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.FeedsQty);
                    return recipesIQ;
                case "FeedsQty":
                    recipesIQ = recipesIQ.OrderBy(r => r.FeedsQty);
                    return recipesIQ;
                case "creatorid_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.CreatorId);
                    return recipesIQ;
                case "CreatorID":
                    recipesIQ = recipesIQ.OrderBy(r => r.CreatorId);
                    return recipesIQ;
                default:
                    recipesIQ = recipesIQ.OrderBy(r => r.Title);
                    return recipesIQ;
            }
        }
    }
}
