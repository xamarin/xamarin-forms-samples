using Xamarin.Forms.Platform.Tizen;

namespace CustomRenderer.Tizen
{
    public class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            MainWindow.AvailableRotations = ElmSharp.DisplayRotation.Degree_0;
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}
