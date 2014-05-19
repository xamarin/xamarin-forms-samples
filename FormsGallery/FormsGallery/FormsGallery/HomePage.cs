using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGallery
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Command<Type> navigateCommands = 
                new Command<Type>((Type pageType) =>
                {
                    if (pageType == null)
                    {
                        this.DisplayAlert("Gallery", "Page not yet implemented", "OK", null);
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
                        new TableSection("Views for Presentation")
                        {
                            new TextCell
                            {
                                Text = "Label",
                                Command = navigateCommands,
                                CommandParameter = typeof(LabelDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Image",
                                Command = navigateCommands,
                                CommandParameter = typeof(ImageDemoPage)
                            },

                            new TextCell
                            {
                                Text = "BoxView",
                                Command = navigateCommands,
                                CommandParameter = typeof(BoxViewDemoPage)
                            },

                            new TextCell
                            {
                                Text = "WebView",
                                Command = navigateCommands,
                                CommandParameter = typeof(WebViewDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Map",
                                Command = navigateCommands,
                                CommandParameter = typeof(MapDemoPage)
                            }
                        }, 

                        new TableSection("Views to Indicate Activity")
                        {
                            new TextCell
                            {
                                Text = "ActivityIndicator",
                                Command = navigateCommands,
                                CommandParameter = typeof(ActivityIndicatorDemoPage)
                            },

                            new TextCell
                            {
                                Text = "ProgressBar",
                                Command = navigateCommands,
                                CommandParameter = typeof(ProgressBarDemoPage)
                            }
                        },

                        new TableSection("Views for Commands")
                        {
                            new TextCell
                            {
                                Text = "Button",
                                Command = navigateCommands,
                                CommandParameter = typeof(ButtonDemoPage)
                            }
                        },

                        new TableSection("Views for Common Data Types")
                        {
                            new TextCell
                            {
                                Text = "Slider (double)",
                                Command = navigateCommands,
                                CommandParameter = typeof(SliderDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Stepper (double)",
                                Command = navigateCommands,
                                CommandParameter = typeof(StepperDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Switch (bool)",
                                Command = navigateCommands,
                                CommandParameter = typeof(SwitchDemoPage)
                            },

                            new TextCell
                            {
                                Text = "DatePicker",
                                Command = navigateCommands,
                                CommandParameter = typeof(DatePickerDemoPage)
                            },

                            new TextCell
                            {
                                Text = "TimePicker",
                                Command = navigateCommands,
                                CommandParameter = typeof(TimePickerDemoPage)
                            }
                        },

                        new TableSection("Views for Editing Text")
                        {
                            new TextCell
                            {
                                Text = "Entry (single line)",
                                Command = navigateCommands,
                                CommandParameter = typeof(EntryDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Editor (multiple lines)",
                                Command = navigateCommands,
                                CommandParameter = typeof(EditorDemoPage)
                            }
                        }
                    }
                };
        }
    }
}
