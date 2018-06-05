using Microsoft.Practices.Unity;
using PluralsightPrismDemo.Infrastructure;
using PluralsightPrismDemo.Statusbar.View;
using PluralsightPrismDemo.Statusbar.ViewModel;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Statusbar
{
    [Module(ModuleName = "StatusbarModule", OnDemand = true)]
    public class StatusbarModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public StatusbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IStatusbarView, StatusbarView>();
            _container.RegisterType<IStatusbarViewModel, StatusbarViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(IStatusbarView));
        }
    }
}
