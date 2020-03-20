using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.ViewModels
{
    public class RegistrationCodeViewModel : BaseViewModel
    {
        readonly App app;
        string registrationCode;
        ICommand verifyRegistrationCodeCommand;
        ICommand returnToPreviousViewCommand;

        public string RegistrationTitle => "Xamarin.Forms C# Markup";
        public string RegistrationSubTitle => "Registration code demo";
        public string RegistrationPrompt { get; set; } = "Your test registration code is 123456.\n\nPlease enter it below";

        public string RegistrationCode
        {
            get { return registrationCode; }
            set
            {
                registrationCode = value;
                if (Regex.IsMatch(registrationCode, @"^\d{6}$"))
                {
                    IsRegistrationCodeFormatValid = true;
                    RegistrationCodeValidationMessage = null;
                }
                else
                {
                    IsRegistrationCodeFormatValid = false;
                    RegistrationCodeValidationMessage = "6 digits";
                }
            }
        }

        public bool IsRegistrationCodeFormatValid { get; set; }

        public bool CanVerifyRegistrationCode => IsRegistrationCodeFormatValid;

        public string RegistrationCodeValidationMessage { get; set; }

        public ICommand VerifyRegistrationCodeCommand { get { return verifyRegistrationCodeCommand ?? (verifyRegistrationCodeCommand = new RelayCommandAsync(SaveRegistrationCode)); } }

        public ICommand ReturnToPreviousViewCommand => returnToPreviousViewCommand ?? (returnToPreviousViewCommand = new RelayCommandAsync(ReturnToPreviousView));

        public RegistrationCodeViewModel(App app)
        {
            this.app = app;
        }

        Task SaveRegistrationCode() => app.DisplayAlert("Registration", $"Registered code { RegistrationCode }");

        Task ReturnToPreviousView() => app.ReturnToPreviousView();
    }
}
