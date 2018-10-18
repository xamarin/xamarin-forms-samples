using System;
using Autofac;
using ViewModelFirstNavigation.ViewModels;
using ViewModelFirstNavigation.Views;

namespace ViewModelFirstNavigation.Bootstrapping.Modules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirstView>().SingleInstance();
            builder.RegisterType<FirstViewModel>().SingleInstance();

            builder.RegisterType<SecondView>();
            builder.RegisterType<SecondViewModel>();
        }
    }
}
