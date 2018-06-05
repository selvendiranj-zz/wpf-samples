using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure;
using PluralsightPrismDemo.People.ViewModel;
using Prism.Common;
using Prism.Regions;
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

namespace PluralsightPrismDemo.People.View
{
    /// <summary>
    /// Interaction logic for PeopleDetailsView.xaml
    /// </summary>
    public partial class PeopleDetailsView : UserControl, IPeopleDetailsView
    {
        public IViewModel ViewModel
        {
            get { return (IPeopleDetailsViewModel)DataContext; }
            set { DataContext = value; }
        }

        public PeopleDetailsView(IPeopleDetailsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
            {
                var context = (ObservableObject<object>)s;
                var selectedPerson = (Person)context.Value;
                (ViewModel as IPeopleDetailsViewModel).SelectedPerson = selectedPerson;
            };
        }
    }
}
