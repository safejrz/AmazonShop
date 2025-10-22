using System.Collections;
using Ecommerce.Application.Persistence;

namespace Ecommerce.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? repositories;

    private readonly EcommerceDbContext _context;

    public UnitOfWork(EcommerceDbContext context)
    {
        _context = context;
    }

    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            throw new Exception("Error en transaccion.", ex);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (repositories == null)
        {
            repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)repositories[type]!;
    }
}
