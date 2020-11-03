using MOS.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOS.DataAccessLayer
{
    internal class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IDB<T> _db;

        public Repository()
        {
            this._db = DbFactory<T>.Create();
        }

        Task<bool> IRepository<T>.Insert(T type)
        {
            return this._db.Insert(type);
        }

        Task<T> IRepository<T>.Select(object PkId, IEnumerable<string> navproperties)
        {
            return this._db.Select(PkId, navproperties);
        }

        Task<IEnumerable<T>> IRepository<T>.SelectAll()
        {
            return this._db.SelectAll();
        }

        Task<IEnumerable<T>> IRepository<T>.SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            return this._db.SelectList(columnAndvalue);
        }

        Task<bool> IRepository<T>.Update(T type, Object pkid)
        {
            return this._db.Update(type, pkid);
        }

        Task<bool> IRepository<T>.Delete(object PkId)
        {
            return this._db.Delete(PkId);
        }

        Task<bool> IRepository<T>.Any(Expression<Func<T, bool>> any)
        {
            return this._db.Any(any);
        }

        Task<IEnumerable<TType>> IRepository<T>.Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select)
        {
            return this._db.Get(where, select);
        }

        Task<T> IRepository<T>.FirstOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return this._db.FirstOrDefaultAsync(condition);
        }

        Task<T> IRepository<T>.SingleOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return this._db.SingleOrDefaultAsync(condition);
        }

        Task<IEnumerable<T>> IRepository<T>.SelectedList(Expression<Func<T, bool>> condition)
        {
            return this._db.SelectedList(condition);
        }

        public Task<bool> InsertList(List<T> type)
        {
            return this._db.InsertList(type);
        }

        public Task<bool> DeleteList(List<T> type)
        {
            return this._db.DeleteList(type);
        }
    }
}