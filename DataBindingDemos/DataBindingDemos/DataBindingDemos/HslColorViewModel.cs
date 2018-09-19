using System.ComponentModel;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class HslColorViewModel : INotifyPropertyChanged
    {
        Color color;
        string name; 

        public event PropertyChangedEventHandler PropertyChanged;

        public double Hue
        {
            set
            {
                if (color.Hue != value)
                {
                    Color = Color.FromHsla(value, color.Saturation, color.Luminosity);
                }
            }
            get 
            {
                return color.Hue;
            }
        }

        public double Saturation
        {
            set
            {
                if (color.Saturation != value)
                {
                    Color = Color.FromHsla(color.Hue, value, color.Luminosity);
                }
            }
            get
            {
                return color.Saturation;
            }
        }

        public double Luminosity
        {
            set
            {
                if (color.Luminosity != value)
                {
                    Color = Color.FromHsla(color.Hue, color.Saturation, value);
                }
            }
            get
            {
                return color.Luminosity;
            }
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Saturation"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Luminosity"));
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
