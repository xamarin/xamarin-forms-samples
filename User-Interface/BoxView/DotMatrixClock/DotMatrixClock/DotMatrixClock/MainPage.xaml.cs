using System;
using Xamarin.Forms;

namespace DotMatrixClock
{
    public partial class MainPage : ContentPage
    {
        // Total dots horizontally and vertically.
        const int horzDots = 41;
        const int vertDots = 7;

        // 5 x 7 dot matrix patterns for 0 through 9.
        static readonly int[, ,] numberPatterns = new int[10, 7, 5]
        {
            {
                { 0, 1, 1, 1, 0}, { 1, 0, 0, 0, 1}, { 1, 0, 0, 1, 1}, { 1, 0, 1, 0, 1}, 
                { 1, 1, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}
            },
            {
                { 0, 0, 1, 0, 0}, { 0, 1, 1, 0, 0}, { 0, 0, 1, 0, 0}, { 0, 0, 1, 0, 0}, 
                { 0, 0, 1, 0, 0}, { 0, 0, 1, 0, 0}, { 0, 1, 1, 1, 0}
            },
            {
                { 0, 1, 1, 1, 0}, { 1, 0, 0, 0, 1}, { 0, 0, 0, 0, 1}, { 0, 0, 0, 1, 0}, 
                { 0, 0, 1, 0, 0}, { 0, 1, 0, 0, 0}, { 1, 1, 1, 1, 1}
            },
            {
                { 1, 1, 1, 1, 1}, { 0, 0, 0, 1, 0}, { 0, 0, 1, 0, 0}, { 0, 0, 0, 1, 0},
                { 0, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}
            },
            {
                { 0, 0, 0, 1, 0}, { 0, 0, 1, 1, 0}, { 0, 1, 0, 1, 0}, { 1, 0, 0, 1, 0}, 
                { 1, 1, 1, 1, 1}, { 0, 0, 0, 1, 0}, { 0, 0, 0, 1, 0}
            },
            {
                { 1, 1, 1, 1, 1}, { 1, 0, 0, 0, 0}, { 1, 1, 1, 1, 0}, { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}
            },
            {
                { 0, 0, 1, 1, 0}, { 0, 1, 0, 0, 0}, { 1, 0, 0, 0, 0}, { 1, 1, 1, 1, 0}, 
                { 1, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}
            },
            {
                { 1, 1, 1, 1, 1}, { 0, 0, 0, 0, 1}, { 0, 0, 0, 1, 0}, { 0, 0, 1, 0, 0}, 
                { 0, 1, 0, 0, 0}, { 0, 1, 0, 0, 0}, { 0, 1, 0, 0, 0}
            },
            {
                { 0, 1, 1, 1, 0}, { 1, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}, 
                { 1, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 0}
            },
            {
                { 0, 1, 1, 1, 0}, { 1, 0, 0, 0, 1}, { 1, 0, 0, 0, 1}, { 0, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, { 0, 0, 0, 1, 0}, { 0, 1, 1, 0, 0}
            },
        };

        // Dot matrix pattern for a colon.
        static readonly int[,] colonPattern = new int[7, 2]
        {
            { 0, 0 }, { 1, 1 }, { 1, 1 }, { 0, 0 }, { 1, 1 }, { 1, 1 }, { 0, 0 }
        };

        // BoxView colors for on and off.
        static readonly Color colorOn = Color.Red;
        static readonly Color colorOff = new Color(0.5, 0.5, 0.5, 0.25);

        // Box views for 6 digits, 7 rows, 5 columns.
        BoxView[, ,] digitBoxViews = new BoxView[6, 7, 5];

        public MainPage()
        {
            InitializeComponent();

            // BoxView dot dimensions.
            double height = 0.85 / vertDots;
            double width = 0.85 / horzDots;

            // Create and assemble the BoxViews.
            double xIncrement = 1.0 / (horzDots - 1);
            double yIncrement = 1.0 / (vertDots - 1);
            double x = 0;

            for (int digit = 0; digit < 6; digit++)
            {
                for (int col = 0; col < 5; col++)
                {
                    double y = 0;

                    for (int row = 0; row < 7; row++)
                    {
                        // Create the digit BoxView and add to layout.
                        BoxView boxView = new BoxView();
                        digitBoxViews[digit, row, col] = boxView;
                        absoluteLayout.Children.Add(boxView,
                                                    new Rectangle(x, y, width, height),
                                                    AbsoluteLayoutFlags.All);
                        y += yIncrement;
                    }
                    x += xIncrement;
                }
                x += xIncrement;

                // Colons between the hours, minutes, and seconds.
                if (digit == 1 || digit == 3)
                {
                    int colon = digit / 2;

                    for (int col = 0; col < 2; col++)
                    {
                        double y = 0;

                        for (int row = 0; row < 7; row++)
                        {
                            // Create the BoxView and set the color.
                            BoxView boxView = new BoxView
                                {
                                    Color = colonPattern[row, col] == 1 ?
                                                colorOn : colorOff
                                };
                            absoluteLayout.Children.Add(boxView,
                                                        new Rectangle(x, y, width, height),
                                                        AbsoluteLayoutFlags.All);
                            y += yIncrement;
                        }
                        x += xIncrement;
                    }
                    x += xIncrement;
                }
            }

            // Set the timer and initialize with a manual call.
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimer);
            OnTimer();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // No chance a display will have an aspect ratio > 41:7
            absoluteLayout.HeightRequest = vertDots * Width / horzDots;
        }

        bool OnTimer()
        {
            DateTime dateTime = DateTime.Now;

            // Convert 24-hour clock to 12-hour clock.
            int hour = (dateTime.Hour + 11) % 12 + 1;

            // Set the dot colors for each digit separately.
            SetDotMatrix(0, hour / 10);
            SetDotMatrix(1, hour % 10);
            SetDotMatrix(2, dateTime.Minute / 10);
            SetDotMatrix(3, dateTime.Minute % 10);
            SetDotMatrix(4, dateTime.Second / 10);
            SetDotMatrix(5, dateTime.Second % 10);
            return true;
        }

        void SetDotMatrix(int index, int digit)
        {
            for (int row = 0; row < 7; row++)
                for (int col = 0; col < 5; col++)
                {
                    bool isOn = numberPatterns[digit, row, col] == 1;
                    Color color = isOn ? colorOn : colorOff;
                    digitBoxViews[index, row, col].Color = color;
                }
        }
    }
}
