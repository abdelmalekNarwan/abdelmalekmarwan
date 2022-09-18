using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology.Reposatory
{
    public interface IReposatory<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task remove(TEntity entity);
        Task Update(TEntity entity);

    }
}
