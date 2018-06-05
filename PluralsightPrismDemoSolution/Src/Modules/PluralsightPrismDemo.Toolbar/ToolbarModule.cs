using Microsoft.Practices.Unity;
using PluralsightPrismDemo.Infrastructure;
using PluralsightPrismDemo.Toolbar.View;
using PluralsightPrismDemo.Toolbar.ViewModel;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Toolbar
{
    [Module(ModuleName = "ToolbarModule", OnDemand = true)]
    public class ToolbarModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ToolbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IToolbarView, ToolbarView>(); 
            _container.RegisterType<IToolbarViewModel, ToolbarViewModel>(); 

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(IToolbarView));
        }
    }
}
