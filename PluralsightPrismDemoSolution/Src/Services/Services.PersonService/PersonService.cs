using PluralsightPrismDemo.Business;
using PluralsightPrismDemo.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        private static readonly string Avatar1Uri = @"/Services.PersonService;component/XamlCatalog.xaml";
        private static readonly string Avatar2Uri = @"/Services.PersonService;component/XamlCatalog.xaml";

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                var person = new Person();
                person.FirstName = string.Format("First{0}", i);
                person.LastName = string.Format("Last{0}", i);
                person.Age = i;
                person.Email = string.Format("{0}.{1}@domain.com", person.FirstName, person.LastName);
                person.ImagePath = GetPersonImagePath(i);
                people.Add(person);
                Thread.Sleep(80); //simulate longer process
            }
            return people;
        }

        public void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (o, e) =>
            {
                e.Result = GetPeople();
            };
            bw.RunWorkerCompleted += (o, e) =>
            {
                callback.Invoke(this, new ServiceResult<IList<Person>>((IList<Person>)e.Result));
            };
        }

        private string GetPersonImagePath(int i)
        {
            return string.Empty;
        }
    }
}
