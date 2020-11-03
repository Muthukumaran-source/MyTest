using System;
using Unity;

namespace MOS.BusinessLayer
{
    public static class BusinessFactory<T> where T : class, new()
    {
        private static readonly IUnityContainer container = new UnityContainer();

        static BusinessFactory()
        {
            Register();
        }

        private static void Register()
        {
            container.RegisterType<IBusiness<T>, BusinessBL<T>>();
        }

        private static IBusiness<T> Resolve()
        {
            return container.Resolve<BusinessBL<T>>();
        }

        public static IBusiness<T> Create()
        {
            return Resolve();
        }
    }
}
