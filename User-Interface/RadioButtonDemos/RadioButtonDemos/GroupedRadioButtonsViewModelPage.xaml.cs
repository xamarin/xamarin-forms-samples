using Xamarin.Forms;

namespace RadioButtonDemos
{
    public partial class GroupedRadioButtonsViewModelPage : ContentPage
    {
        public GroupedRadioButtonsViewModelPage()
        {
            InitializeComponent();
            BindingContext = new AnimalViewModel
            {
                GroupName = "animals",
                Selection = "Monkey"
            };
        }
    }
}
