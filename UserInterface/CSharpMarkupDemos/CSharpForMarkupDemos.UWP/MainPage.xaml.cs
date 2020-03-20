using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            TaskHelper.InitializeFromUIThread();
            this.InitializeComponent();
            this.LoadApplication(new CSharpForMarkupDemos.App());
        }
    }
}
