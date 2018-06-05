using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace MvvmExample.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        bool? _CloseWindowFlag;
        public event PropertyChangedEventHandler PropertyChanged;

        //basic ViewModelBase
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        //Extra Stuff, shows why a base ViewModel is useful
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null ? true : !CloseWindowFlag;
            }));
        }
    }
}
