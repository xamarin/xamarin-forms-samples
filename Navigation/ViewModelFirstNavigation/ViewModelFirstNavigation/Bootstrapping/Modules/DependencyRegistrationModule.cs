using System;
using Autofac;
using ViewModelFirstNavigation.Interfaces;
using ViewModelFirstNavigation.Services;
using Xamarin.Forms;

namespace ViewModelFirstNavigation.Bootstrapping.Modules
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
