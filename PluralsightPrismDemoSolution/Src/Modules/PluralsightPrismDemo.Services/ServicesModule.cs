using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightPrismDemo.Infrastructure;

namespace PluralsightPrismDemo.Services
{
    public class ServicesModule : IModule
    {
        IUnityContainer _container;

        public ServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IPersonRepository, PersonRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
