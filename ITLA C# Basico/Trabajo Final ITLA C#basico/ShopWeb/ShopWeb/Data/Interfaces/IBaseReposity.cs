using ShopWeb.Data.Class;
using System.Linq.Expressions;

namespace ShopWeb.Data.Interfaces
{
    public interface IBaseReposity<TEntity, TResult,TResultList> where TEntity : class
    {
        Task<TResult>Save(TEntity entity);
        Task<TResult>Update(TEntity entity);
        Task<TResult>Remove(TEntity entity);
        Task<TResultList> GetAll();
        Task<TResultList> GetAll(Func<TEntity,bool>filtrer);
        Task<TResult> GetEntityBy(int Id);
        Task <bool> Exists (Func<TEntity, bool> filtrer);

    }
}
