using Xamarin.Forms;

namespace BrushesDemos.Controls
{
    public class ColorSource : BindableObject
    {
        Color color;
        bool isSelected;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        public ColorSource(Color color)
        {
            Color = color;
        }
    }
}
