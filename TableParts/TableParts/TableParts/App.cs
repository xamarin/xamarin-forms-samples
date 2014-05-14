using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TableParts
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new ContentPage
            {
                Content = new TableView
                {
                    Intent = TableIntent.Form,
                    Root = new TableRoot ("Table Title")
                    {
                        new TableSection("Section 1 Title")
                        {


                            // The Text and Detail strings are vertically stacked
                            // in Android and Windows Phone but horizontally
                            // stacked on iPhone.


                            new TextCell
                            {
                                Text = "TextCell Text",
                                Detail = "TextCell Detail"
                            },


                            // The image below doesn't show up on iPhone and Android


                            new ImageCell
                            {
                                Text = "ImageCell Text",
                                Detail = "ImageCell Detail",
                                ImageSource = "http://xamarin.com/images/index/ide-xamarin-studio.png"
                            },
                            new EntryCell
                            {
                                Label = "EntryCell:",
                                Placeholder = "default keyboard",
                                Keyboard = Keyboard.Default
                            }
                        },
                        new TableSection("Section 2 Title")
                        {
                            new EntryCell
                            {
                                Label = "Another EntryCell:",
                                Placeholder = "phone keyboard",
                                Keyboard = Keyboard.Telephone
                            },
                            new SwitchCell
                            {
                                Text = "SwitchCell:"
                            },


                            // This custom ViewCell raises an exception on Windows Phone
                            // because ViewToRendererConverter.WrapperControl returns infinity
                            // from its MeasureOverride.


                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Children = 
                                    {
                                        new Label
                                        {
                                            Text = "Custom Slider View:"
                                        },
                                        new Slider
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
