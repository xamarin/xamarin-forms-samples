using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSSafeAreaPageCS : ContentPage
    {
        public iOSSafeAreaPageCS()
        {
            On<iOS>().SetUseSafeArea(true);

            var toggleButton = new Button { Text = "Disable Use Safe Area" };
            toggleButton.Clicked += (sender, e) =>
            {
                On<iOS>().SetUseSafeArea(false);
                (sender as Button).IsEnabled = false;
            };

            Title = "Safe Area";
            Content = new StackLayout
            {
                Margin = new Thickness(0, 120, 0, 0),
                Children = {
                    new Label { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quis enim redargueret? At modo dixeras nihil in istis rebus esse, quod interesset. Et quidem, inquit, vehementer errat; Semper enim ex eo, quod maximas partes continet latissimeque funditur, tota res appellatur. Equidem, sed audistine modo de Carneade? Duo Reges: constructio interrete." },
                    toggleButton
                }
            };
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var safeInsets = On<iOS>().SafeAreaInsets();
        //    safeInsets.Left = 20;
        //    Padding = safeInsets;
        //}
    }
}
