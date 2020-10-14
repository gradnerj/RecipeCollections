using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class CategoryRespository : Repository<Category>, ICategoryRepository {
        private readonly ApplicationDbContext _context;
        public CategoryRespository(ApplicationDbContext context):base(context) {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown() {
            return _context.Categories.Select(i => new SelectListItem() {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
    }
}
