using DonAR.Core.Data;
using DonAR.Core.Def.Repositories;
using DonAR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Core.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : Entity
    {
        protected DbSet<T> table;
        private bool _disposed = false;

        public GenericRepository(DonarContext dataContext)
        {
            table = dataContext.Set<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(int id)
        {
            // Sidenote: the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return table.Single(e => e.Id.Equals(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (table != null)
                {
                    table = null;
                }
            }

            this._disposed = true;   
        }
        #endregion
    }
}