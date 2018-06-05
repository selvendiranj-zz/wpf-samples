using PluralsightPrismDemo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Infrastructure.Services
{
    public interface IPersonService
    {
        void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback);
    }
}
