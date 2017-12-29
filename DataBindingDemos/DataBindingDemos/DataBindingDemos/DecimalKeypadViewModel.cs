using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class DecimalKeypadViewModel : INotifyPropertyChanged
    {
        string entry = "0";

        public event PropertyChangedEventHandler PropertyChanged;

        public DecimalKeypadViewModel()
        {
            DigitCommand = new Command<string>(
                (string arg) =>
                {
                    Entry += arg;
                    Entry = Double.Parse(Entry).ToString();
                },
                (string arg) =>
                {
                    return arg != "." && !entry.Contains(".");
                });


        }

        public string Entry
        {
            private set
            {
                if (entry != value)
                {
                    entry = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
                }
            }
            get
            {
                return entry;
            }
        }

        public ICommand DigitCommand { private set; get; }

        public ICommand ClearCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }
    }
}
