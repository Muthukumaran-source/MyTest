using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOS.BusinessLayer
{
    public interface IBusiness<T> where T : class
    {
        Task<T> Select(Object PkId, IEnumerable<string> navproperties = null);
        Task<IEnumerable<T>> SelectAll();
        Task<bool> Any(Expression<Func<T, bool>> any);
        Task<IEnumerable<TType>> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> SelectedList(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> SelectList(KeyValuePair<string, object> columnAndvalue);
        Task<bool> Insert(T type);

        Task<bool> InsertList(List<T> type);
        Task<bool> Update(T type, Object pkid = null);
        Task<bool> Delete(Object PkId);

        Task<bool> DeleteList(List<T> type);
    }
}
