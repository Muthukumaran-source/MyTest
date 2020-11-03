using MOS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOS.BusinessLayer
{
    public class BusinessBL<T> : IBusiness<T> where T : class, new()
    {
        private readonly IRepository<T> _repository;

        public BusinessBL()
        {
            this._repository = DataAccessFactory<T>.Create();
        }

        public virtual async Task<bool> Insert(T type)
        {
            return await this._repository.Insert(type);
        }

        public virtual async Task<T> Select(object PkId, IEnumerable<string> navproperties = null)
        {
            return await this._repository.Select(PkId, navproperties);
        }

        public virtual async Task<IEnumerable<T>> SelectAll()
        {
            return await this._repository.SelectAll();
        }

        public virtual Task<IEnumerable<T>> SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            return this._repository.SelectList(columnAndvalue);
        }

        public virtual async Task<bool> Update(T type, Object pkid = null)
        {
            return await this._repository.Update(type, pkid);
        }

        public virtual async Task<bool> Delete(object PkId)
        {
            return await this._repository.Delete(PkId);
        }

        public virtual async Task<bool> Any(Expression<Func<T, bool>> any)
        {
            return await this._repository.Any(any);
        }

        public virtual async Task<IEnumerable<TType>> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select)
        {
            return await this._repository.Get(where, select);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await _repository.FirstOrDefaultAsync(condition);
        }

        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await this._repository.SingleOrDefaultAsync(condition);
        }

        public virtual async Task<IEnumerable<T>> SelectedList(Expression<Func<T, bool>> condition)
        {
            return await this._repository.SelectedList(condition);
        }

        public virtual async Task<bool> InsertList(List<T> type)
        {
            return await this._repository.InsertList(type);
        }
        public virtual async Task<bool> DeleteList(List<T> type)
        {
            return await this._repository.DeleteList(type);
        }
    }
}
