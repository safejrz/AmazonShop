namespace Ecommerce.Application.Persistence;

public interface IUnitOfWork
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;

    Task<int> Complete();

}