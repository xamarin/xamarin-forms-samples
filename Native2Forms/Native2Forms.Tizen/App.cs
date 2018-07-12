using ElmSharp;
using System;
using Xamarin.Forms.Platform.Tizen;

namespace Native2Forms.Tizen
{
    public class Program : FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        public void Initialize()
        {
            Window window = MainWindow;
            window.BackButtonPressed += (s, e) =>
            {
                Exit();
            };
            window.Show();

            var box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var bg = new Background(window)
            {
                Color = Color.White
            };
            bg.SetContent(box);

            var conformant = new Conformant(window);
            conformant.Show();
            conformant.SetContent(bg);

            var label = new Label(window)
            {
                Text = "Hello, Native Tizen here!",
                Color = Color.Black
            };
            label.Show();

            var but = new Button(window);
            box.PackEnd(label);
            but.AlignmentX = -1;
            but.Text = "To Xamarin Page";
            but.Clicked += (s, e) =>
            {
                var a = new App();
                LoadApplication(a);
                conformant.Hide();
            };
            but.Show();
            box.PackEnd(but);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app);
            app.Run(args);
        }
    }
}
