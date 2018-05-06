using MammasTiffin.DataAccess.Repository;
using MammasTiffin.Entities.EntityFramework;
using System;

namespace MammasTiffin.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MammasTiffinDbContext _mammasTiffinDbContext = new MammasTiffinDbContext();
        private bool _isDisposed = false;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_mammasTiffinDbContext);
        }

        public virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    _mammasTiffinDbContext.Dispose();
                }
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _mammasTiffinDbContext.SaveChanges();
        }
    }
}
