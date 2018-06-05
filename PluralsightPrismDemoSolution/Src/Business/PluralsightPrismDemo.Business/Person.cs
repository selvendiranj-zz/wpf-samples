using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Business
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public bool IsValid { get { return _errors.Count == 0; } }
        
        #region Properties

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private int? _age;
        public int? Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get
            {
                return _lastUpdated;
            }
            set
            {
                _lastUpdated = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                ValidateModel(propertyName);
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ValidateModel(string propertyName)
        {
            switch (propertyName)
            {
                case "FirstName":
                    if (string.IsNullOrEmpty(_firstName))
                    {
                        _errors["FirstName"] = "First Name required";
                    }
                    else
                    {
                        _errors.Remove("FirstName");
                    }
                    break;
                case "LastName":
                    if (string.IsNullOrEmpty(_lastName))
                    {
                        _errors["LastName"] = "Last Name required";
                    }
                    else
                    {
                        _errors.Remove("LastName");
                    }
                    break;
                case "Age":
                    if (string.IsNullOrEmpty(_age.ToString()))
                    {
                        _errors["Age"] = "Age required";
                    }
                    else if (_age < 18 || _age > 85)
                    {
                        _errors["Age"] = "Age is out of range";
                    }
                    else
                    {
                        _errors.Remove("Age");
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region IDataErrorInfo

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return _errors.ContainsKey(columnName) ? _errors[columnName] : null;
            }
        }

        #endregion
    }
}
