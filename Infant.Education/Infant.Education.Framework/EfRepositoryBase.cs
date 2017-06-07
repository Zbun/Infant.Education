using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework
{
    public class EfRepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
    {
        public EfRepositoryBase(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        private IUnitOfWork UnitOfWork { get; set; }

        protected IUnitOfWorkContext EFContext
        {
            get
            {
                if (UnitOfWork is IUnitOfWorkContext)
                {
                    return UnitOfWork as IUnitOfWorkContext;
                }
                throw new Exception(string.Format("数据仓储上下文对象类型不正确，应为IRepositoryContext，实际为 {0}", UnitOfWork.GetType().Name));
            }
        }

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities
        {
            get { return EFContext.Set<TEntity>(); }
        }

        public async Task<long> Count()
        {
            return await Entities.CountAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllList(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            EFContext.RegisterNew(entity);
            EFContext.Commit();
        }

        public void Update(TEntity entity)
        {
            EFContext.RegisterModified(entity);
            EFContext.Commit();
        }

        public void Delete(TEntity entity)
        {
            EFContext.RegisterDeleted(entity);
            EFContext.Commit();
        }
    }


    public class EfRepositoryBaseOfDbContext<TEntity> :EfRepositoryBase<EfDbContext,TEntity>
    where TEntity : Entity
    {
        public EfRepositoryBaseOfDbContext(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

    }
}
