﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface ICategoryRepository : IRepository<Category>{
        IEnumerable<SelectListItem> GetCategoryListForDropDown();
    }
}
