using System;
using System.ComponentModel;

namespace MvvmExample.Model
{
    public class Person : INotifyPropertyChanged
    {
        string _FirstName;
        string _LastName;
        int _Age;

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
