using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.DAL.Repositories.Interfaces;

namespace NewsAggregator.DAL.Repositories.Implementation.Repositories
{
    public abstract class RepositoryWithAdd<T> : Repository<T>, IRepositoryWithAdd<T> where T : class, IBaseEntity
    {
        protected RepositoryWithAdd(NewsAggregatorContext context) : base(context)
        {
        }

        public void Add(T t)
        {
            Table.Add(t);
        }
    }
}