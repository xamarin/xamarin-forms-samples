using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MenuItemDemos.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> items;
        public List<string> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public ListPageViewModel()
        {
            Items = new List<string>();
        }

        public ListPageViewModel(List<string> startingItems)
        {
            Items = startingItems;
        }

        public ICommand EditCommand => new Command<string>((string item) =>
        {
            Message = $"Edit command was called on: {item}";
        });

        public ICommand DeleteCommand => new Command<string>((string item) =>
        {
            Message = $"Delete command was called on: {item}";
        });

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
