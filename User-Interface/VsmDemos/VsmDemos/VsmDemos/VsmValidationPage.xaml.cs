using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace VsmDemos
{
    public partial class VsmValidationPage : ContentPage
    {
        public VsmValidationPage()
        {
            InitializeComponent();

            GoToState(false);
        }

        void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = Regex.IsMatch(args.NewTextValue, @"^[2-9]\d{2}-\d{3}-\d{4}$");
            GoToState(isValid);
        }

        void GoToState(bool isValid)
        {
            string visualState = isValid ? "Valid" : "Invalid";
            VisualStateManager.GoToState(stackLayout, visualState);
        }
    }
}