using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PluralsightPrismDemo.Infrastructure;
using ModuleA.ViewModel;

namespace ModuleA.View
{
    /// <summary>
    /// Interaction logic for ContentA.xaml
    /// </summary>
    public partial class ContentAView : UserControl, IContentAView
    {
        //ViewModel First
        //public ContentAView()
        //{
        //    InitializeComponent();
        //}

        //ViewModel First
        public ContentAView(IContentAViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IContentAViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
