using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using PluralsightPrismDemo.Infrastructure;
using ExcelImport.View;

namespace ExcelImport
{
    [Module(ModuleName = "ExcelImport", OnDemand = true)]
    public class ExcelImportModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ExcelImportModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //experiment with regions here
            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(Nullable));
            //IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            //region.Add(_container.Resolve<ToolbarView>());
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
