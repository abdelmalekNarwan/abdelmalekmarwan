using AmanaTechnology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology.Reposatory
{
    public class Reposatory<TEntity> : IReposatory<TEntity> where TEntity : class
    {

        protected readonly AmanaDbContext _dbContext;
        public Reposatory(AmanaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> Get(int Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }
        public async Task Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public async Task Update(TEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();

        }
        public async Task remove(TEntity entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
