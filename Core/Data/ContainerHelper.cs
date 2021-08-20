using CMP332.MVVM.Models.User;
using Unity;
using Unity.Lifetime;

namespace CMP332.Core.Data
{
    public class ContainerHelper
    {
        public ContainerHelper()
        {
            Container = new UnityContainer();

            Container.RegisterType<IRepository<User>, SQLRepository<User>>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRepository<Role>, SQLRepository<Role>>(new ContainerControlledLifetimeManager());
        }
        
        public static IUnityContainer Container { get; private set; }
    }
}