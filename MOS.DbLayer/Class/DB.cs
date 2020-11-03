using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOS.DbLayer
{
    internal abstract class DB<T> : IDB<T> where T : class
    {
        public abstract Task<bool> Insert(T type);

        public abstract Task<bool> InsertList(List<T> type);
        public abstract Task<T> Select(Object PkId, IEnumerable<string> navproperties = null);
        public abstract Task<bool> Any(Expression<Func<T, bool>> any);
        public abstract Task<IEnumerable<TType>> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select);
        public abstract Task<IEnumerable<T>> SelectAll();
        public abstract Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition);
        public abstract Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> condition);
        public abstract Task<IEnumerable<T>> SelectedList(Expression<Func<T, bool>> condition);
        public abstract Task<IEnumerable<T>> SelectList(KeyValuePair<string, object> columnAndvalue);
        public abstract Task<bool> Update(T type, Object PkId);
        public abstract Task<bool> Delete(Object PkId);

        public abstract Task<bool> DeleteList(List<T> type);
    }
}
