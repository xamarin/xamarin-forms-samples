using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ButtonDemos
{
    class CommandDemoViewModel : INotifyPropertyChanged
    {
        double number = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public CommandDemoViewModel()
        {
            MultiplyBy2Command = new Command(() => Number *= 2);

            DivideBy2Command = new Command(() => Number /= 2);
        }

        public double Number
        {
            set
            {
                if (number != value)
                {
                    number = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
                }
            }
            get
            {
                return number;
            }
        }

        public ICommand MultiplyBy2Command { private set; get; }

        public ICommand DivideBy2Command { private set; get; }
    }
}
