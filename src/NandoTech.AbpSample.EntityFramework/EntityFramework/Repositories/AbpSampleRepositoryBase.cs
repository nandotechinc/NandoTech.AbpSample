using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace NandoTech.AbpSample.EntityFramework.Repositories
{
    public abstract class AbpSampleRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpSampleDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AbpSampleRepositoryBase(IDbContextProvider<AbpSampleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AbpSampleRepositoryBase<TEntity> : AbpSampleRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AbpSampleRepositoryBase(IDbContextProvider<AbpSampleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
