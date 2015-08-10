using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinFormsSample.Model
{
    /// <summary>
    ///   This is a domain object that holds information about a given employee.
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        string _firstName;
        string _imageUri;
        string _lastName;
        string _twitter;

        public Employee()
        {
            ImageUri = "VC";
        }

        public string DisplayName { get { return string.Format("{0}, {1}", _lastName, _firstName); } }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Equals(_firstName, StringComparison.Ordinal))
                {
                    return;
                }
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged("DisplayName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Equals(_lastName, StringComparison.Ordinal))
                {
                    return;
                }
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged("DisplayName");
            }
        }

        public string Twitter
        {
            get { return _twitter; }
            set
            {
                if (value.Equals(_twitter, StringComparison.Ordinal))
                {
                    return;
                }
                _twitter = value;
                OnPropertyChanged();
            }
        }

        public string ImageUri
        {
            get { return _imageUri; }
            set
            {
                if (value.Equals(_imageUri, StringComparison.Ordinal))
                {
                    return;
                }
                _imageUri = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // Required by INotifyPropertyChanged

        /// <summary>
        ///   This is a helper method that will raise the PropertyChanged event when a property is changed.
        /// </summary>
        /// <param name="propertyName">Property name. If null, then this property will hold the name of the member that invoked it.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
