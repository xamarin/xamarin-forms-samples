using System;
using Autofac;
using ViewModelFirstNavigation.Bootstrapping.Modules;
using ViewModelFirstNavigation.Interfaces;
using ViewModelFirstNavigation.ViewModels;
using ViewModelFirstNavigation.Views;
using Xamarin.Forms;

namespace ViewModelFirstNavigation.Bootstrapping
{
    public class Bootstrapper
    {
        private readonly App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        private void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();

            var mainPage = viewFactory.Resolve<FirstViewModel>();
            var navPage = new NavigationPage(mainPage);

            _app.MainPage = navPage;
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DependencyRegistrationModule>();
            builder.RegisterModule<ViewModelViewRegistrationModule>();
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<FirstViewModel, FirstView>();
            viewFactory.Register<SecondViewModel, SecondView>();
        }
    }
}
