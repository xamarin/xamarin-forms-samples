using Xamarin.Forms.Platform.Tizen;

namespace TipCalc.Tizen
{
    public class Program : FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app, true);
            app.Run(args);
        }
    }
}
