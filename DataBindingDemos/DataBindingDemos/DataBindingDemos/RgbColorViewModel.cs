using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class RgbColorViewModel : INotifyPropertyChanged
    {
        Color color;
        string name; 

        public event PropertyChangedEventHandler PropertyChanged;

        public double Red
        {
            set
            {
                if (color.R != value)
                {
                    Color = new Color(value, color.G, color.B);
                }
            }
            get 
            {
                return color.R;
            }
        }

        public double Green
        {
            set
            {
                if (color.G != value)
                {
                    Color = new Color(color.R, value, color.B);
                }
            }
            get
            {
                return color.G;
            }
        }

        public double Blue
        {
            set
            {
                if (color.B != value)
                {
                    Color = new Color(color.R, color.G, value);
                }
            }
            get
            {
                return color.B;
            }
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Green"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Blue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                    Name = NamedColor.GetNearestColorName(color);
                }
            }
            get
            {
                return color;
            }
        }

        public string Name
        {
            private set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            get
            {
                return name;
            }
        }
    }
}
