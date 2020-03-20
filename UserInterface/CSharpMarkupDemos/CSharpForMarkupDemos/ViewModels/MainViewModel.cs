using System.Threading.Tasks;
using System.Windows.Input;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly App app;

        ICommand continueToRegistrationCommand;
        ICommand continueToNestedListCommand;
        ICommand continueToCSharpForMarkupCommand;
        ICommand continueToAnimatedPageCommand;

        public string Title => "Xamarin.Forms C# Markup";
        public string SubTitle => "Demos";

        public ICommand ContinueToRegistrationCommand => continueToRegistrationCommand ?? (continueToRegistrationCommand = new RelayCommandAsync(ContinueToRegistration));
        public ICommand ContinueToNestedListCommand => continueToNestedListCommand ?? (continueToNestedListCommand = new RelayCommandAsync(ContinueToNestedList));
        public ICommand ContinueToAnimatedPageCommand => continueToAnimatedPageCommand ?? (continueToAnimatedPageCommand = new RelayCommandAsync(ContinueToAnimatedPage));
        public ICommand ContinueToCSharpForMarkupCommand => continueToCSharpForMarkupCommand ?? (continueToCSharpForMarkupCommand = new RelayCommandAsync(ContinueToCSharpForMarkup));
        
        public MainViewModel(App app)
        {
            this.app = app;
        }

        Task ContinueToRegistration() => app.ContinueToRegistration();
        Task ContinueToNestedList() => app.ContinueToNestedList();
        Task ContinueToAnimatedPage() => app.ContinueToAnimatedPage();
        Task ContinueToCSharpForMarkup() => app.OpenUri("https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/csharp-markup");
    }
}
