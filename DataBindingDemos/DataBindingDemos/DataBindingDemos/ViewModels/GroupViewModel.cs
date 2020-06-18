using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingDemos
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        #region Fields and Properties

        EmployeeViewModel employee1 = new EmployeeViewModel
        {
            Forename = "Gaius",
            MiddleName = "Julius",
            Surname = "Caesar",
            IsOver16 = true,
            HasPassedTest = false,
            IsSuspended = false
        };

        EmployeeViewModel employee2 = new EmployeeViewModel
        {
            Forename = "William",
            MiddleName = "Henry",
            Surname = "Gates",
            IsOver16 = true,
            HasPassedTest = true,
            IsSuspended = false
        };

        EmployeeViewModel employee3 = new EmployeeViewModel
        {
            Forename = "John",
            MiddleName = "Fitzgerald",
            Surname = "Kennedy",
            IsOver16 = true,
            HasPassedTest = true,
            IsSuspended = false
        };

        EmployeeViewModel employee4 = new EmployeeViewModel
        {
            Forename = "Harry",
            MiddleName = "James",
            Surname = "Potter",
            IsOver16 = false,
            HasPassedTest = true,
            IsSuspended = false
        };

        EmployeeViewModel employee5 = new EmployeeViewModel
        {
            Forename = "Queen",
            MiddleName = "Elizabeth",
            Surname = "II",
            IsOver16 = true,
            HasPassedTest = false,
            IsSuspended = false,
            IsMonarch = true
        };

        public EmployeeViewModel Employee1
        {
            get => employee1;
            set
            {
                employee1 = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel Employee2
        {
            get => employee2;
            set
            {
                employee2 = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel Employee3
        {
            get => employee3;
            set
            {
                employee3 = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel Employee4
        {
            get => employee4;
            set
            {
                employee4 = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel Employee5
        {
            get => employee5;
            set
            {
                employee5 = value;
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel Employee6
        {
            get => null;
        }

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
