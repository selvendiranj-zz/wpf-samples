using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Controls;
using PluralsightPrismDemo.Infrastructure;
//using ModuleA;

namespace PluralsightPrismDemo
{
    public class Bootstrapper: UnityBootstrapper
    {
        /// <summary>
        /// Create Shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Initialize Shell
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configure Region Adapter Mappings
        /// </summary>
        /// <returns></returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }

        //protected override void ConfigureModuleCatalog()
        //{
        //    Type moduleType = typeof(ModuleAModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleType.Name,
        //        ModuleType = moduleType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable
        //    });
        //}

        /// <summary>
        /// Creates Module Catalog. use when defining Modules in resource file XamlCatalog.xaml
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return Prism.Modularity.ModuleCatalog.CreateFromXaml(
                new Uri("/PluralsightPrismDemo;component/XamlCatalog.xaml", UriKind.Relative));
        }

        /// <summary>
        /// use MEF bootstrapper
        /// </summary>
        //protected override void ConfigureAggregateCatalog()
        //{

        //}

        /// <summary>
        /// Creates Module Catalog. use when defining Modules in app.config
        /// </summary>
        /// <returns></returns>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}
    }
}
