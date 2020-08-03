using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "DragAndDrop_Experimental", "Shapes_Experimental" });
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
