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
using PluralsightPrismDemo.People.ViewModel;

namespace PluralsightPrismDemo.People.View
{
    /// <summary>
    /// Interaction logic for PeopleView.xaml
    /// </summary>
    public partial class PeopleView : UserControl, IPeopleView
    {
        public IViewModel ViewModel
        {
            get { return (IPeopleViewModel)DataContext; }
            set { DataContext = value; }
        }

        public PeopleView(IPeopleViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
