using System;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUnitOfWork : IDisposable {

        IRecipeRepository Recipe { get; }

        IReviewRepository Review { get; }

        IApplicationUserRepository ApplicationUser { get; }

        ICategoryRepository Category { get; }
        void Save();
    }
}
