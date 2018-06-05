using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Prism.Unity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using PluralsightPrismDemo.Infrastructure;
using Prism.Mef.Modularity;
using ModuleA.View;
using ModuleA.ViewModel;
using PluralsightPrismDemo.Infrastructure.Services;

namespace ModuleA
{
    [Module(ModuleName = "ModuleA", OnDemand = true)]
    //[ModuleDependency("")]
    //[ModuleExport(typeof(ModuleAModule), InitializationMode=InitializationMode.WhenAvailable)] //MefBootstrap
    public class ModuleAModule: IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //experiment with regions here
            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            //IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            //region.Add(_container.Resolve<ToolbarView>());
            //region.Add(_container.Resolve<ToolbarView>());
            //region.Add(_container.Resolve<ToolbarView>());
            //region.Add(_container.Resolve<ToolbarView>());
            //region.Add(_container.Resolve<ToolbarView>());
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));

            //Register the views
            _container.RegisterType<ToolbarAView>();
            //_container.RegisterType<ContentAView>(); //View First approach
            _container.RegisterType<IContentAView, ContentAView>(); //ViewModel First approach
            _container.RegisterType<IContentAViewModel, ContentAViewModel>(); //Both ViewModel and View First approach
            _container.RegisterType<IPersonService, PersonService>();
            //View Discovery - Compose the view into MVVM
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarAView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentAView));

            var vm = _container.Resolve<IContentAViewModel>();
            //View Injection
            //_regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);

            //More controls on the region
            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];
            vm.Message = "First View";
            region.Add(vm.View);
            //region.Activate(vm.View);
            //region.Deactivate(vm.View);

            var vm2 = _container.Resolve<IContentAViewModel>();
            vm.Message = "Second View";
            region.Add(vm2.View);
        }
    }
}
