using PluralsightPrismDemo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Infrastructure.Services
{
    public class ServiceResult<T>
    {
        private IList<Person> result;

        public ServiceResult(IList<Person> result)
        {
            this.result = result;
        }
    }
}
