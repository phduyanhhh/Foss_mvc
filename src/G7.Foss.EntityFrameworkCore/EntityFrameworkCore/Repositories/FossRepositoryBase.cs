using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace G7.Foss.EntityFrameworkCore.Repositories;

public abstract class FossRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<FossDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    protected FossRepositoryBase(IDbContextProvider<FossDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}

public abstract class FossRepositoryBase<TEntity> : FossRepositoryBase<TEntity, int>, IRepository<TEntity>
    where TEntity : class, IEntity<int>
{
    protected FossRepositoryBase(IDbContextProvider<FossDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

}
