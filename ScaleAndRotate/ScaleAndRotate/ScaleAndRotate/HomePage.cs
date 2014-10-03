using System;
using Xamarin.Forms;

namespace ScaleAndRotate
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Command<Type> navigateCommand = 
                new Command<Type>(async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await this.Navigation.PushAsync(page);
                });

            this.Title = "Scale and Rotate";

            this.Content = new TableView
                {
                    Intent = TableIntent.Menu,
                    Root = new TableRoot
                    {
                        new TableSection()
                        {
                            new TextCell
                            {
                                Text = "Scale",
                                Command = navigateCommand,
                                CommandParameter = typeof(ScaleDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Rotation",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotationX",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationXDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotationY",
                                Command = navigateCommand,
                                CommandParameter = typeof(RotationYDemoPage)
                            }
                        }
                    }
                };
        }
    }
}
