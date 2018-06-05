using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.People.ViewModel
{
    public interface IPersonViewModel: IViewModel
    {
        Person Person { get; set; }

        void CreatePerson(string firstName, string lastName);
    }
}
