using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RpnCalculator
{
    public class RpnCalculatorViewModel : INotifyPropertyChanged
    {
        string entry = "0";
        Stack<double> stack = new Stack<double>();

        public event PropertyChangedEventHandler PropertyChanged;

        public RpnCalculatorViewModel()
        {
            ClearCommand = new Command(
                execute: () =>
                {
                    stack.Clear();
                    Entry = "0";
                    RefreshCanExecutes();
                    RefreshStackDisplay();
                });

            ClearEntryCommand = new Command(
                execute: () =>
                {
                    Entry = "0";
                    RefreshCanExecutes();
                });

            BackspaceCommand = new Command(
                execute: () =>
                {
                    Entry = Entry.Substring(0, Entry.Length - 1);
                    if (Entry == "")
                    {
                        Entry = "0";
                    }
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return Entry.Length > 1 || Entry != "0";
                });

            DigitCommand = new Command<string>(
                execute: (string arg) =>
                {
                    Entry += arg;
                    if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
                    {
                        Entry = Entry.Substring(1);
                    }
                    RefreshCanExecutes();
                },
                canExecute: (string arg) =>
                {
                    return !(arg == "." && Entry.Contains("."));
                });

            EnterCommand = new Command(
                execute: () =>
                {
                    stack.Push(double.Parse(Entry));
                    Entry = "0";
                    RefreshStackDisplay();
                    RefreshCanExecutes();
                });

            UnaryOperation = new Command<string>(
                (string op) =>
                {
                    double arg = stack.Pop();
                    double result = 0;

                    switch (op)
                    {
                        case "log10": result = Math.Log10(arg); break;
                        case "log": result = Math.Log(arg); break;
                        case "exp": result = Math.Exp(arg); break;
                        case "sqrt": result = Math.Sqrt(arg); break;
                        case "sin": result = Math.Sin(arg); break;
                        case "cos": result = Math.Cos(arg); break;
                        case "tan": result = Math.Tan(arg); break;
                        case "invert": result = 1 / arg; break;
                        case "asin": result = Math.Asin(arg); break;
                        case "acos": result = Math.Acos(arg); break;
                        case "atan": result = Math.Atan(arg); break;
                        case "negate": result = -arg; break;
                        case "radians": result = Math.PI * arg / 180; break;
                        case "degrees": result = 180 * arg / Math.PI; break;
                    }

                    stack.Push(result);
                    RefreshStackDisplay();
                },
                (string op) =>
                {
                    return stack.Count > 0;
                });

            BinaryOperation = new Command<string>(
                execute: (string op) =>
                {
                    double x = stack.Pop();
                    double y = stack.Pop();
                    double result = 0;

                    switch (op)
                    {
                        case "divide": result = y / x; break;
                        case "multiply": result = y * x; break;
                        case "subtract": result = y - x; break;
                        case "add": result = y + x; break;
                        case "pow": result = Math.Pow(y, x); break;
                        case "swap": stack.Push(x); result = y; break;
                    }

                    stack.Push(result);
                    RefreshCanExecutes();
                    RefreshStackDisplay();
                },
                canExecute: (string op) =>
                {
                    return stack.Count > 1;
                });
        }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
            ((Command)UnaryOperation).ChangeCanExecute();
            ((Command)BinaryOperation).ChangeCanExecute();
        }

        void RefreshStackDisplay()
        {
            OnPropertyChanged("XStackValue");
            OnPropertyChanged("YStackValue");
        }

        public string Entry
        {
            private set { SetProperty(ref entry, value); }
            get { return entry; }
        }

        public string XStackValue
        {
            get { return stack.Count > 0 ? stack.Peek().ToString() : ""; }
        }

        public string YStackValue
        {
            get
            {
                string result = "";

                if (stack.Count > 1)
                {
                    double hold = stack.Pop();
                    result = stack.Peek().ToString();
                    stack.Push(hold);
                }

                return result;
            }
        }

        public ICommand ClearCommand { private set; get; }

        public ICommand ClearEntryCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }

        public ICommand DigitCommand { private set; get; }

        public ICommand EnterCommand { private set; get; }

        public ICommand UnaryOperation { private set; get; }

        public ICommand BinaryOperation { private set; get; }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
