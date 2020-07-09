using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FormsGallery.CodeExamples
{
    public class PathDemoPage : ContentPage
    {
        public PathDemoPage()
        {
            Label header = new Label
            {
                Text = "Path",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Path path = new Path
            {
                Stroke = Color.Black,
                Aspect = Stretch.Uniform,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 100,
                WidthRequest = 100,
                Data = new PathGeometry
                {
                    Figures = new PathFigureCollection
                    {
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 13.908992, Y = 16.207977 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 32.000048, Y = 16.207977 } },
                                new LineSegment { Point = new Point { X = 32.000049, Y = 31.999985 } },
                                new LineSegment { Point = new Point { X = 13.908992, Y = 30.109983 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 0, Y = 16.207977 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 11.904009, Y = 16.207977 } },
                                new LineSegment { Point = new Point { X = 11.904009, Y = 29.900984 } },
                                new LineSegment { Point = new Point { X = 0, Y = 28.657984 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 11.904036, Y = 2.0979624 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 11.904036, Y = 14.202982 } },
                                new LineSegment { Point = new Point { X = 2.7656555E-05, Y = 14.202982 } },
                                new LineSegment { Point = new Point { X = 2.7656555E-05, Y = 3.3409645 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 32.000058, Y = 0},
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 32.000058, Y = 14.203001 } },
                                new LineSegment { Point = new Point { X = 13.909059, Y = 14.203001 } },
                                new LineSegment { Point = new Point { X = 13.909059, Y = 1.8890382 } }
                            }
                        }
                    }
                }
            };

            // Build the page.
            Title = "Path Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    path
                }
            };
        }
    }
}

