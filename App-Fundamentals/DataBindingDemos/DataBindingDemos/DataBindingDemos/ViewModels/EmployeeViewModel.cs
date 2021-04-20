using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingDemos
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region Properties

        string forename;
        public string Forename
        {
            get
            {
                return forename;
            }
            set
            {
                if (forename != value)
                {
                    forename = value;
                    OnPropertyChanged();
                }
            }
        }

        string middleName;
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    OnPropertyChanged();
                }
            }
        }

        string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }

        bool isOver16;
        public bool IsOver16
        {
            get
            {
                return isOver16;
            }
            set
            {
                if (isOver16 != value)
                {
                    isOver16 = value;
                    OnPropertyChanged();
                }
            }
        }

        bool hasPassedTest;
        public bool HasPassedTest
        {
            get
            {
                return hasPassedTest;
            }
            set
            {
                if (hasPassedTest != value)
                {
                    hasPassedTest = value;
                    OnPropertyChanged();
                }
            }
        }

        bool isSuspended;
        public bool IsSuspended
        {
            get
            {
                return isSuspended;
            }
            set
            {
                if (isSuspended != value)
                {
                    isSuspended = value;
                    OnPropertyChanged();
                }
            }
        }

        bool isMonarch;
        public bool IsMonarch
        {
            get
            {
                return isMonarch;
            }
            set
            {
                if (isMonarch != value)
                {
                    isMonarch = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FullName => Forename + " " + MiddleName + " " + Surname;
        //public bool CanDrive => IsOver16 && HasPassedTest && !IsSuspended;

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
