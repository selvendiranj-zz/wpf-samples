using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.People.ViewModel
{
    public class PeopleDetailsViewModel : ViewModelBase, IPeopleDetailsViewModel
    {
        public PeopleDetailsViewModel() : base() { }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged(); }
        }
    }
}
