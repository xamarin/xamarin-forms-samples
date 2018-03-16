using Windows.UI.Xaml.Controls;

namespace HelloXamarinFormsWorld.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadApplication(new HelloXamarinFormsWorld.App());
        }
    }
}
