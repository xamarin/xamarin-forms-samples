using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace ScaleAndRotate
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Command<Type> navigateCommand = 
                new Command<Type>((Type pageType) =>
                {
                    if (pageType == null)
                    {
                        this.DisplayAlert("ScaleAndRotate", 
                                    "Page not yet implemented", "OK", null);
                        return;
                    }

                    // Get all the constructors of the page type.
                    IEnumerable<ConstructorInfo> constructors = 
                            pageType.GetTypeInfo().DeclaredConstructors;

                    foreach (ConstructorInfo constructor in constructors)
                    {
                        // Check if the constructor has no parameters.
                        if (constructor.GetParameters().Length == 0)
                        {
                            // If so, instantiate it, and navigate to it.
                            Page page = (Page)constructor.Invoke(null);
                            this.Navigation.Push(page);
                            break;
                        }
                    }
                });

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
                                Text = "Rotate",
                                Command = navigateCommand,
                           //     CommandParameter = typeof(RotateDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotateX",
                                Command = navigateCommand,
                            //    CommandParameter = typeof(RotateXDemoPage)
                            },

                            new TextCell
                            {
                                Text = "RotateY",
                                Command = navigateCommand,
                          //      CommandParameter = typeof(RotateYDemoPage)
                            }
                        }
                    }
                };
        }
    }
}
