
using BoletoBusApp.Data.Base;
using System.Linq.Expressions;

namespace BoletoBusApp.Data.Interfaces
{
    public interface IBaseRepository<TEntity,TType,TModel> where TEntity : class
    {
        Task<OperationResult<TModel>> Save (TEntity entity);
        Task<OperationResult<TModel>> Update(TEntity entity);
        Task<OperationResult<TModel>> Remove(TEntity entity);
        Task<OperationResult<List<TModel>>> GetAll();
        Task<OperationResult<List<TModel>>> GetAll(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult<TModel>> GetEntityBy(TType id);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
