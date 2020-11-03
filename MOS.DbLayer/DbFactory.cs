using MOS.Domain.Helpers;
using System;
using Unity;

namespace MOS.DbLayer
{
    public static class DbFactory<T> where T : class, new()
    {
        private static readonly DbType _dbtype;
        private static readonly IUnityContainer container = new UnityContainer();

        static DbFactory()
        {
            Register();
            var databaseType = ConfigManager.ConfigRoot.GetSection("Data:DataBaseType").Value;
            _dbtype = string.IsNullOrEmpty(databaseType) ? 0 : (DbType)Enum.Parse(typeof(DbType), databaseType, true);
        }

        private static void Register()
        {
            container.RegisterType<IDB<T>, SqlDB<T>>(typeof(SqlDB<T>).Name);
        }

        private static IDB<T> Resolve(string type)
        {
            return container.Resolve<IDB<T>>(type);
        }

        public static IDB<T> Create()
        {
            return _dbtype switch
            {
                DbType.SqlDB => Resolve(typeof(SqlDB<T>).Name),
                DbType.MongoDB => null,
                DbType.OracleDB => null,
                DbType.MySqlDB => null,
                _ => Resolve(typeof(SqlDB<T>).Name),
            };
        }
    }
}
