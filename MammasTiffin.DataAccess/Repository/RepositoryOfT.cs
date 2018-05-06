using MammasTiffin.Entities.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MammasTiffin.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MammasTiffinDbContext _mammasTiffinDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MammasTiffinDbContext mammasTiffinDbContext)
        {
            this._mammasTiffinDbContext = mammasTiffinDbContext;
            this._dbSet = this._mammasTiffinDbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Data
        {
            get
            {
                return _dbSet;
            }
        }
        public void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public void Dispose()
        {
            _mammasTiffinDbContext.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            _dbSet.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _mammasTiffinDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
