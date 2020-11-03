using Microsoft.EntityFrameworkCore;
using MOS.Domain.SqlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOS.DbLayer
{
    internal class SqlDB<T> : DB<T> where T : class, new()
    {
        private readonly OnlineShopContext _dbContext = new OnlineShopContext();
        private readonly DbSet<T> table;

        public SqlDB()
        {
            table = _dbContext.Set<T>();
        }

        /* Only for Entity framework */
        public override async Task<bool> Insert(T type)
        {
            bool result;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    table.Add(type);
                    result = await _dbContext.SaveChangesAsync() > 0;
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }

        /* Only for Entity framework */
        public override async Task<bool> InsertList(List<T> type)
        {
            bool result;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    table.AddRange(type);
                    result = await _dbContext.SaveChangesAsync() > 0;
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }



        public override async Task<T> Select(Object PkId, IEnumerable<string> navproperties = null)
        {
            var model = await table.FindAsync(PkId);
            if (model != null && navproperties != null)
            {
                foreach (var property in navproperties)
                {
                    try
                    {
                        _dbContext.Entry(model).Collection(property).Load();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return model;
        }

        /// <summary>
        ///  Can check value existing or not.
        /// </summary>
        /// <param name="any"></param>
        /// <returns>Returns true or false.</returns>
        public override async Task<bool> Any(Expression<Func<T, bool>> any)
        {
            return await table.AnyAsync(any);
        }

        /// <summary>
        /// Can get condition based records.
        /// </summary>
        /// <typeparam name="TType">It specify the return of model.</typeparam>
        /// <param name="where">It specify the condtion.</param>
        /// <param name="select">It specify the required values.</param>
        /// <returns>Return list of selected column values.</returns>
        public override async Task<IEnumerable<TType>> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select)
        {
            try
            {
                return await table.Where(where).Select(select).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        /// <summary>
        /// Here, we can get a model based on condition.
        /// </summary>
        /// <param name="condition">It specify the condition.</param>
        /// <returns>Return the first model based on condition.</returns>
        public override async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await table.FirstOrDefaultAsync(condition);
        }

        /// <summary>
        /// Here, we can get a model based on the condition.
        /// </summary>
        /// <param name="condition">It specify the condition.</param>
        /// <returns>Return the model based on condition.</returns>
        public override async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await table.SingleOrDefaultAsync(condition);
        }

        /// <summary>
        /// Here, We can get selected model based on the condition.
        /// </summary>
        /// <param name="condition">It specify the condition.</param>
        /// <returns>Returns the list of model based on condition.</returns>
        public override async Task<IEnumerable<T>> SelectedList(Expression<Func<T, bool>> condition)
        {
            return await table.Where(condition).ToListAsync();
        }

        public override async Task<IEnumerable<T>> SelectAll()
        {
            return await table.ToListAsync();
        }

        public override async Task<IEnumerable<T>> SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            return await table.ToListAsync();
        }

        public override async Task<bool> Update(T type, Object PkId)
        {
            bool result;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    table.Add(type);
                    foreach (var entry in _dbContext.ChangeTracker.Entries())
                    {
                        if (Convert.ToInt32(entry.Metadata.FindPrimaryKey().Properties.Select(p => entry.Property(p.Name).CurrentValue).FirstOrDefault()) > 0)
                            entry.State = EntityState.Modified;
                        else
                            entry.State = EntityState.Added;
                    }
                    result = await _dbContext.SaveChangesAsync() > 0;
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }

        public override async Task<bool> Delete(Object PkId)
        {
            bool result;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    table.Remove(table.Find(PkId));
                    result = await _dbContext.SaveChangesAsync() > 0;
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }


        public override async Task<bool> DeleteList(List<T> type)
        {
            bool result;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    table.RemoveRange(type);
                    result = await _dbContext.SaveChangesAsync() > 0;
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }
    }
}
