using Xamarin.Forms;

namespace Forms2Native.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadApplication(new Forms2Native.App());
            MessagingCenter.Subscribe<MyFirstPage, NativeNavigationArgs>(this, Forms2Native.App.NativeNavigationMessage, HandleNativeNavigationMessage);
        }

        void HandleNativeNavigationMessage(MyFirstPage sender, NativeNavigationArgs args)
        {
            sender.Navigation.PushAsync(args.Page);
        }
    }
}
