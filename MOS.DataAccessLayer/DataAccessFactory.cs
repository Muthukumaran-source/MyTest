using System;
using System.Collections.Generic;
using System.Text;

namespace MOS.DataAccessLayer
{
    public static class DataAccessFactory<T> where T : class, new()
    {
        public static IRepository<T> Create()
        {
            return new Repository<T>();
        }
    }
}
