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
                Stroke = SolidColorBrush.Black,
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
                            StartPoint = new Point { X = 13.9, Y = 16.2 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 32, Y = 16.2 } },
                                new LineSegment { Point = new Point { X = 32, Y = 31.9 } },
                                new LineSegment { Point = new Point { X = 13.9, Y = 30.1 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 0, Y = 16.2 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 11.9, Y = 16.2 } },
                                new LineSegment { Point = new Point { X = 11.9, Y = 29.9 } },
                                new LineSegment { Point = new Point { X = 0, Y = 28.6 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 11.9, Y = 2 },
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 11.9, Y = 14.2 } },
                                new LineSegment { Point = new Point { X = 0, Y = 14.2 } },
                                new LineSegment { Point = new Point { X = 0, Y = 3.3 } }
                            }
                        },
                        new PathFigure
                        {
                            IsClosed = true,
                            StartPoint = new Point { X = 32, Y = 0},
                            Segments = new PathSegmentCollection
                            {
                                new LineSegment { Point = new Point { X = 32, Y = 14.2 } },
                                new LineSegment { Point = new Point { X = 13.9, Y = 14.2 } },
                                new LineSegment { Point = new Point { X = 13.9, Y = 1.8 } }
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

