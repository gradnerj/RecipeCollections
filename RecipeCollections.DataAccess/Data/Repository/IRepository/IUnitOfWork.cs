using System;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUnitOfWork : IDisposable {

        ICreatorRepository Creator { get; }
        IRecipeRepository Recipe { get; }
        IIngredientRepository Ingredient { get; }
        IReviewRepository Review { get; }
        IStepRepository Step { get; }
        IUntensilRepository Utensil { get; }

        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
