using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework
{

    public interface IRepository
    {

    }

    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        Task<IEnumerable<TEntity>> GetAllList(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);

        

        void Delete(TEntity entity);

        void Update(TEntity entity);

        Task<long> Count();

    }
}

