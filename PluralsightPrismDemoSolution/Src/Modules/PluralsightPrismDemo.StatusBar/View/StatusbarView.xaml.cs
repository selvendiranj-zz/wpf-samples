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
using PluralsightPrismDemo.Statusbar.ViewModel;

namespace PluralsightPrismDemo.Statusbar.View
{
    /// <summary>
    /// Interaction logic for StatusbarView.xaml
    /// </summary>
    public partial class StatusbarView : UserControl, IStatusbarView
    {
        public IViewModel ViewModel
        {
            get
            {
                return (IStatusbarViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }

        public StatusbarView(IStatusbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
