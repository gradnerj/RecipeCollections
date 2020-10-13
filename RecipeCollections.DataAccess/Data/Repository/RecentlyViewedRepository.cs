using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class RecentlyViewedRepository : Repository<RecentlyViewed>, IRecentlyViewedRepository {

        private readonly ApplicationDbContext _db;
        public RecentlyViewedRepository(ApplicationDbContext db): base(db) {
            _db = db;
        }

        public int DecrementCount(RecentlyViewed recentlyViewed, int count) {
            recentlyViewed.Count -= count;
            return recentlyViewed.Count;
        }

        public int IncrementCount(RecentlyViewed recentlyViewed, int count) {
            recentlyViewed.Count += count;
            return recentlyViewed.Count;
        }
    }
}
