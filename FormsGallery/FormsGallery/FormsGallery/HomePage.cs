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
            Command<Type> navigateCommand = 
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
                                Command = navigateCommand,
                                CommandParameter = typeof(LabelDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Image",
                                Command = navigateCommand,
                                CommandParameter = typeof(ImageDemoPage)
                            },

                            new TextCell
                            {
                                Text = "BoxView",
                                Command = navigateCommand,
                                CommandParameter = typeof(BoxViewDemoPage)
                            },

                            new TextCell
                            {
                                Text = "WebView",
                                Command = navigateCommand,
                                CommandParameter = typeof(WebViewDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Map",
                                Command = navigateCommand,
                                CommandParameter = typeof(MapDemoPage)
                            }
                        }, 

                        new TableSection("Views that Initiate Commands")
                        {
                            new TextCell
                            {
                                Text = "Button",
                                Command = navigateCommand,
                                CommandParameter = typeof(ButtonDemoPage)
                            },

                            new TextCell
                            {
                                Text = "SearchBar",
                                Command = navigateCommand,
                                CommandParameter = typeof(SearchBarDemoPage)
                            }
                        },

                        new TableSection("Views for Common Data Types")
                        {
                            new TextCell
                            {
                                Text = "Slider (double)",
                                Command = navigateCommand,
                                CommandParameter = typeof(SliderDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Stepper (double)",
                                Command = navigateCommand,
                                CommandParameter = typeof(StepperDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Switch (bool)",
                                Command = navigateCommand,
                                CommandParameter = typeof(SwitchDemoPage)
                            },

                            new TextCell
                            {
                                Text = "DatePicker",
                                Command = navigateCommand,
                                CommandParameter = typeof(DatePickerDemoPage)
                            },

                            new TextCell
                            {
                                Text = "TimePicker",
                                Command = navigateCommand,
                                CommandParameter = typeof(TimePickerDemoPage)
                            }
                        },

                        new TableSection("Views for Editing Text")
                        {
                            new TextCell
                            {
                                Text = "Entry (single line)",
                                Command = navigateCommand,
                                CommandParameter = typeof(EntryDemoPage)
                            },

                            new TextCell
                            {
                                Text = "Editor (multiple lines)",
                                Command = navigateCommand,
                                CommandParameter = typeof(EditorDemoPage)
                            }
                        },

                        new TableSection("Views to Indicate Activity")
                        {
                            new TextCell
                            {
                                Text = "ActivityIndicator",
                                Command = navigateCommand,
                                CommandParameter = typeof(ActivityIndicatorDemoPage)
                            },

                            new TextCell
                            {
                                Text = "ProgressBar",
                                Command = navigateCommand,
                                CommandParameter = typeof(ProgressBarDemoPage)
                            }
                        },

                        new TableSection("Views that Display Collections")
                        {
                            new TextCell
                            {
                                Text = "Picker",
                                Command = navigateCommand,
                                CommandParameter = typeof(PickerDemoPage)
                            },

                            new TextCell
                            {
                                Text = "ListView",
                                Command = navigateCommand,
                                CommandParameter = typeof(ListViewDemoPage)
                            }
                        }
                    }
                };
        }
    }
}
