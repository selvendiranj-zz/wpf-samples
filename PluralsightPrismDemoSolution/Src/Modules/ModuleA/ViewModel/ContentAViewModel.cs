using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightPrismDemo.Infrastructure;
using ModuleA.View;
using System.Collections.ObjectModel;
using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure.Services;

namespace ModuleA.ViewModel
{
    public class ContentAViewModel : ViewModelBase, IContentAViewModel
    {
        private readonly IPersonService _personService;

        #region Properties
        public string Message { get; set; }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { _people = value; OnPropertyChanged(); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;OnPropertyChanged(); }
        }
        #endregion

        #region Constructors

        //ViewModel First
        //public ContentAViewModel(IContentAView view)
        //{
        //    View = view;
        //    View.ViewModel = this;
        //}

        public ContentAViewModel(IPersonService personService) : base()
        {
            _personService = personService;
            LoadPeople();
        }

        #endregion

        #region Commands



        #endregion

        #region Methods

        private void LoadPeople()
        {
            IsBusy = true;
            _personService.GetPeopleAsync((sender, result) =>
            {
                People = new ObservableCollection<Person>((IList<Person>)result);
                IsBusy = false;
            });
        }

        #endregion
    }
}
