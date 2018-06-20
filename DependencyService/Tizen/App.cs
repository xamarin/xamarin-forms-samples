using Xamarin.Forms.Platform.Tizen;

namespace DependencyServiceSample.Tizen
{
    public class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        public static ElmSharp.Window Instance;
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
            Instance = MainWindow;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app, true);
            app.Run(args);
        }
    }
}