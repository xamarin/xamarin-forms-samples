using System;
using Xamarin.Forms;

namespace FormsGallery
{
    public class CodeExamplesMainPage : ContentPage
    {
        public CodeExamplesMainPage()
        {
            // Define command for the items in the TableView.
            Command<Type> navigateCommand =
                new Command<Type>(async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });

            Content = new TableView
            {
                Intent = TableIntent.Menu,
                Root = new TableRoot
                {
                    new TableSection("Views for Presentation")
                    {
                        new TextCell
                        {
                            Text = "BoxView",
                            Detail = "Display a colored rectangle",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.BoxViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Image",
                            Detail = "Display a bitmap",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ImageDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Label",
                            Detail = "Display a text string",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.LabelDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Map",
                            Detail = "Display a map",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.MapDemoPage)
                        },

                        new TextCell
                        {
                            Text = "MediaElement",
                            Detail = "Play video or audio",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.MediaElementDemoPage)
                        },

                        new TextCell
                        {
                            Text = "OpenGLView",
                            Detail = "Display OpenGL Graphics",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.OpenGLViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "WebView",
                            Detail = "Display a Web page",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.WebViewDemoPage)
                        }
                    },

                    new TableSection("Views that Initiate Commands")
                    {
                        new TextCell
                        {
                            Text = "Button",
                            Detail = "Initiate a command",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ButtonDemoPage)
                        },

                        new TextCell
                        {
                            Text = "ImageButton",
                            Detail = "Initiate a command",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ImageButtonDemoPage)
                        },

                        new TextCell
                        {
                            Text = "RefreshView",
                            Detail = "Initiate a command",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.RefreshViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "SearchBar",
                            Detail = "Initiate a search",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.SearchBarDemoPage)
                        },

                        new TextCell
                        {
                            Text = "SwipeView",
                            Detail = "Initiate a command",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.SwipeViewDemoPage)
                        }
                    },

                    new TableSection("Views for Common Data Types")
                    {
                        new TextCell
                        {
                            Text = "CheckBox (bool)",
                            Detail = "Select a Boolean value",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.CheckBoxPage)
                        },

                        new TextCell
                        {
                            Text = "Slider (double)",
                            Detail = "Select a number from a continuous range",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.SliderDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Stepper (double)",
                            Detail = "Select a number from discrete increments",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.StepperDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Switch (bool)",
                            Detail = "Select a Boolean value",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.SwitchDemoPage)
                        },

                        new TextCell
                        {
                            Text = "DatePicker",
                            Detail = "Select a date",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.DatePickerDemoPage)
                        },

                        new TextCell
                        {
                            Text = "TimePicker",
                            Detail = "Select a time",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.TimePickerDemoPage)
                        }
                    },

                    new TableSection("Views for Editing Text")
                    {
                        new TextCell
                        {
                            Text = "Entry (single line)",
                            Detail = "Edit a single line of text",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.EntryDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Editor (multiple lines)",
                            Detail = "Edit a body of text",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.EditorDemoPage)
                        }
                    },

                    new TableSection("Views to Indicate Activity")
                    {
                        new TextCell
                        {
                            Text = "ActivityIndicator",
                            Detail = "Show that the program is busy",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ActivityIndicatorDemoPage)
                        },

                        new TextCell
                        {
                            Text = "ProgressBar",
                            Detail = "Show the progress of a program task",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ProgressBarDemoPage)
                        }
                    },

                    new TableSection("Views that Display Collections")
                    {
                        new TextCell
                        {
                            Text = "CarouselView",
                            Detail = "Present data in a carousel layout",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.CarouselViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "CollectionView",
                            Detail = "Select from a list of data items",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.CollectionViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "ListView",
                            Detail = "Select from a list of data items",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ListViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "IndicatorView",
                            Detail = "Display indicators for each item in a CarouselView",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.IndicatorViewDemoPage)
                        },

                        new TextCell
                        {
                            Text = "Picker",
                            Detail = "Select from a list of text items",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.PickerDemoPage)
                        },

                        new TextCell
                        {
                            Text = "TableView for a menu",
                            Detail = "Show a table suitable for a menu",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.TableViewMenuDemoPage)
                        },

                        new TextCell
                        {
                            Text = "TableView for a form",
                            Detail = "Show a table suitable for a form",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.TableViewFormDemoPage)
                        }
                    },

                    new TableSection("Cells")
                    {
                        new TextCell
                        {
                            Text = "TextCell",
                            Detail="Display text in a ListView or TableView",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.TextCellDemoPage)
                        },

                        new TextCell
                        {
                            Text = "ImageCell",
                            Detail="Display a bitmap in a ListView or TableView",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ImageCellDemoPage)
                        },

                        new TextCell
                        {
                            Text = "SwitchCell",
                            Detail="Display a Switch in a ListView or TableView",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.SwitchCellDemoPage)
                        },

                        new TextCell
                        {
                            Text = "EntryCell",
                            Detail="Display an Entry in a ListView or TableView",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.EntryCellDemoPage)
                        }
                    },

                    new TableSection("Layouts with Single Content")
                    {
                        new TextCell
                        {
                            Text = "ContentView",
                            Detail = "Host a single child",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ContentViewDemoPage)
                        },
                        new TextCell
                        {
                            Text = "Frame",
                            Detail = "Show a rectangle around a single child",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.FrameDemoPage)
                        },
                        new TextCell
                        {
                            Text = "ScrollView",
                            Detail = "Scroll an item too large for the page",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ScrollViewDemoPage)
                        }
                    },

                    new TableSection("Layouts with Multiple Children")
                    {
                        new TextCell
                        {
                            Text = "StackLayout",
                            Detail = "Arrange children in a stack",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.StackLayoutDemoPage)
                        },
                        new TextCell
                        {
                            Text = "AbsoluteLayout",
                            Detail = "Arrange children by coordinate positions",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.AbsoluteLayoutDemoPage)
                        },
                        new TextCell
                        {
                            Text = "Grid",
                            Detail = "Arrange children in a grid",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.GridDemoPage)
                        },
                        new TextCell
                        {
                            Text = "RelativeLayout",
                            Detail = "Arrange children relative to each other",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.RelativeLayoutDemoPage)
                        },
                        new TextCell
                        {
                            Text = "FlexLayout",
                            Detail = "Arrange children in a stack or a wrapped stack",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.FlexLayoutDemoPage)
                        }
                    },

                    new TableSection("Pages")
                    {
                        new TextCell
                        {
                            Text = "ContentPage",
                            Detail = "Present a normal page",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.ContentPageDemoPage)
                        },
                        new TextCell
                        {
                            Text = "NavigationPage",
                            Detail = "Present a navigatable page",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.NavigationPageDemoPage)
                        },
                        new TextCell
                        {
                            Text = "MasterDetailPage",
                            Detail = "Present two pages with a list and an item",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.MasterDetailPageDemoPage)
                        },
                        new TextCell
                        {
                            Text = "TabbedPage",
                            Detail = "Present a page with tabs",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.TabbedPageDemoPage)
                        },
                        new TextCell
                        {
                            Text = "CarouselPage",
                            Detail = "Present a horizontally scrollable page",
                            Command = navigateCommand,
                            CommandParameter = typeof(CodeExamples.CarouselPageDemoPage)
                        }
                    }
                }
            };
        }
    }
}
