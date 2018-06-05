using PluralsightPrismDemo.Infrastructure;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Statusbar.ViewModel
{
    public class StatusbarViewModel : ViewModelBase, IStatusbarViewModel
    {
        IEventAggregator _eventAggregator;
        private string _message = "Ready";
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public StatusbarViewModel(IEventAggregator eventAggregator) : base()
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Subscribe(PersonUpdated);
        }

        private void PersonUpdated(string obj)
        {
            Message = string.Format("{0} was updated", obj);
        }
    }
}
