using Xamarin.Forms;

namespace Forms2Native.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage ()
        {
            InitializeComponent ();

            Forms.Init ();

            LoadApplication (new Forms2Native.App ());

            MessagingCenter.Subscribe<MyFirstPage, NativeNavigationArgs> (
	            this,
	            Forms2Native.App.NativeNavigationMessage,
	            HandleNativeNavigationMessage);
        }

        private void HandleNativeNavigationMessage (MyFirstPage sender, NativeNavigationArgs args)
        {
            sender.Navigation.PushAsync (args.Page);
        }
    }
}
