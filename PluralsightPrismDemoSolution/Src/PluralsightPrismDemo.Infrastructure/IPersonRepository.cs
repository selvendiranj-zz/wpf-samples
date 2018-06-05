using PluralsightPrismDemo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Infrastructure
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}
