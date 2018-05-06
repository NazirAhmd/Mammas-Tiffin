using System;
using System.Collections.Generic;
using System.Linq;

namespace MammasTiffin.DataAccess.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IQueryable<TEntity> Data { get; }
        void Insert(TEntity entityToInsert);
        void Update(TEntity entityToUpdate);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
    }
}
