using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FactoriesDemo
{
    public partial class App : Application
    {
        static readonly Dictionary<Type, Func<object, object>> factories = new Dictionary<Type, Func<object, object>>();

        public App()
        {
            InitializeComponent();

            DependencyResolver.ResolveUsing((type, args) => factories.ContainsKey(type) ? factories[type].Invoke(args) : null);
            MainPage = new NavigationPage(new MainPage());
        }

        public static void Register(Type type, Func<object, object> factory)
        {
            factories[type] = factory;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
