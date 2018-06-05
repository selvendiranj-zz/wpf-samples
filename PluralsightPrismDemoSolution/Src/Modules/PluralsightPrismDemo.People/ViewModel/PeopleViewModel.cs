using PluralsightPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightPrismDemo.Business;

namespace PluralsightPrismDemo.People.ViewModel
{
    public class PeopleViewModel : ViewModelBase, IPeopleViewModel
    {
        public PeopleViewModel() : base()
        {
            _people = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                _people.Add(new Person() { FirstName = "Selvendiran"+i, LastName = "Jayaraman" +i, Age = 30+i});
            }
        }

        private IList<Person> _people;
        public IList<Person> People
        {
            get { return _people;}
            set { _people = value; OnPropertyChanged(); }
        }
    }
}
