using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.People.ViewModel
{
    public interface IPeopleDetailsViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
