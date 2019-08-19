using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CardViewDemo.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string photo;
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
                NotifyPropertyChanged();
            }
        }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        string bio;
        public string Bio
        {
            get
            {
                return bio;
            }
            set
            {
                bio = value;
                NotifyPropertyChanged();
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
