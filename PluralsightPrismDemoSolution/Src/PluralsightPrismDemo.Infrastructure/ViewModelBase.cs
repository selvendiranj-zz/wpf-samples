using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace PluralsightPrismDemo.Infrastructure
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public IView View { get; set; }

        public ViewModelBase()
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
