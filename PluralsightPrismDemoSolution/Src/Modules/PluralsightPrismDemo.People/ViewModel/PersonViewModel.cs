using PluralsightPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.People.ViewModel;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;
using PluralsightPrismDemo.People.View;

namespace PluralsightPrismDemo.People.ViewModel
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        IEventAggregator _eventAggregator;
        public string ViewName
        {
            get { return string.Format("{0}, {1}", Person.LastName, Person.FirstName); }
        }

        public DelegateCommand<Person> SaveCommand { get; set; }
        IPersonRepository _repository;

        private Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public PersonViewModel(IEventAggregator eventAggregator, IPersonRepository repository) : base()
        {
            _eventAggregator = eventAggregator;
            _repository = repository;
            CreatePerson();
            Person.PropertyChanged += Person_PropertyChanged;
            SaveCommand = new DelegateCommand<Person>(Save, CanSave);
            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void Save(Person person)
        {
            //Person.LastUpdated = DateTime.Now;//.AddYears((int)person.Age);
            //Update using Shared Services instead of directly updating here
            int count = _repository.SavePerson(Person);
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(
                string.Format("{0}, {1}; Count: {2}", Person.LastName, Person.FirstName, count));
        }

        private bool CanSave(Person value)
        {
            return Person.IsValid;
        }

        private void CreatePerson()
        {
            Person = new Person()
            {
                FirstName = "Selvendiran",
                LastName = "Jayaraman",
                Age = 30
            };
        }

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0
            };
            Person.PropertyChanged += Person_PropertyChanged;
        }
    }
}
