using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public class TriggerViewModel : BindableObject
    {
        bool isToggled = true;
        public bool IsToggled
        {
            get => isToggled;
            set
            {
                isToggled = value;
                OnPropertyChanged(nameof(IsToggled));
            }
        }
    }
}
