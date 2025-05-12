using System.Linq.Expressions;
using FCG.Domain.Base;
using FCG.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static FCG.Domain.Base.IRepository;

namespace FCG.Infrastructure.Base;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly FCGDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(FCGDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> Adicionar(TEntity entity)
    {
        var addedEntity = DbSet.Add(entity).Entity;
        await SaveChanges();
        return addedEntity;
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task Remover(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}
