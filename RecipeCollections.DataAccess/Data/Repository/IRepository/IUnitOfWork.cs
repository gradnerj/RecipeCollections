using System;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUnitOfWork : IDisposable {


        void Save();
    }
}
