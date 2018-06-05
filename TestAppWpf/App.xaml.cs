using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestAppWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender,StartupEventArgs e)
        {
            // Create the startup window                     
             //ExcelReadingwithEPPLUS wnd = new ExcelReadingwithEPPLUS();
            Window1 wnd = new Window1();
            // Do stuff here, e.g. to the window              
            wnd.Title = "Excel Reader";
            // Show the window  
            wnd.Show();
        }

    }
}
