using Microsoft.Practices.Unity;
using PluralsightPrismDemo.Infrastructure;
using PluralsightPrismDemo.People.View;
using PluralsightPrismDemo.People.ViewModel;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.People
{
    [Module(ModuleName = "PeopleModule", OnDemand = true)]
    public class PeopleModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_container.RegisterType<IPersonViewModel, PersonViewModel>();
            //_container.RegisterType<IPersonView, PersonView>(); 

            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(IPersonView));
            //InitializePerson();
            InitializePeople();
        }

        private void InitializePerson()
        {
            RegisterViewsAndServices();

            IRegion _region = _regionManager.Regions[RegionNames.ContentRegion];

            var view = _container.Resolve<IPersonView>();
            (view.ViewModel as IPersonViewModel).CreatePerson("Bob", "Smith");

            _region.Add(view);
            _region.Activate(view);

            var view2 = _container.Resolve<IPersonView>();
            (view2.ViewModel as IPersonViewModel).CreatePerson("Karl", "Sums");
            _region.Add(view2);

            var view3 = _container.Resolve<IPersonView>();
            (view3.ViewModel as IPersonViewModel).CreatePerson("Jeff", "Lock");
            _region.Add(view3);
        }

        private void InitializePeople()
        {
            RegisterViewsAndServices();

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(IPeopleView));
            _regionManager.RegisterViewWithRegion(RegionNames.PersonDetailsRegion, typeof(IPeopleDetailsView));

        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IPersonView, PersonView>();
            _container.RegisterType<IPersonViewModel, PersonViewModel>();

            _container.RegisterType<IPeopleView, PeopleView>();
            _container.RegisterType<IPeopleViewModel, PeopleViewModel>();
            _container.RegisterType<IPeopleDetailsView, PeopleDetailsView>();
            _container.RegisterType<IPeopleDetailsViewModel, PeopleDetailsViewModel>();
        }
    }
}
