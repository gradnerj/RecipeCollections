using RecipeCollections.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IRecentlyViewedRepository : IRepository<RecentlyViewed> {
        public int IncrementCount(RecentlyViewed recentlyViewed, int count);
        public int DecrementCount(RecentlyViewed recentlyViewed, int count);
    }
}
