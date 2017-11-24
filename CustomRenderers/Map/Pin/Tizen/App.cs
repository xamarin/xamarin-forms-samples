
namespace CustomRenderer.TizenMobile
{
    public class Program : Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            Xamarin.FormsMaps.Init("HERE", "HERE-ENTER_YOUR_KEY_HERE");
            app.Run(args);
        }
    }
}
