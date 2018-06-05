﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Linq;

using System.Windows.Threading;
using WpfModelViewDemoApplication.Controller;

namespace WpfModelViewDemoApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Create the ViewModel and expose it using the View's DataContext
            View.MainView view = new View.MainView();
            view.Show();
        }

        private void APP_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}
