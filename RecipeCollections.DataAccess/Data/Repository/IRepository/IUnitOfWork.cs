using System;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUnitOfWork : IDisposable {

        IRecipeRepository Recipe { get; }
        IIngredientRepository Ingredient { get; }
        IReviewRepository Review { get; }

        IApplicationUserRepository ApplicationUser { get; }
        IRecentlyViewedRepository RecentlyViewed { get; }
        void Save();
    }
}
