using System;
using Xamarin.Forms;

namespace AbsoluteLayoutDemos.Views
{
    public class ChessboardDemoPageCS : ContentPage
    {
        AbsoluteLayout absoluteLayout;

        public ChessboardDemoPageCS()
        {
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.WhiteSmoke,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int row=0; row < 8; row++)
            {
                for (int col=0; col < 8; col++)
                {
                    // Skip every other square
                    if (((row ^ col) & 1) == 0)
                    {
                        continue;
                    }

                    BoxView boxView = new BoxView
                    {
                        Color = Color.Black
                    };

                    // x, y, width, height
                    Rectangle rect = new Rectangle(col / 7.0, row / 7.0, 1 / 8.0, 1 / 8.0);

                    absoluteLayout.Children.Add(boxView, rect, AbsoluteLayoutFlags.All);
                }
            }

            ContentView contentView = new ContentView
            {
                Margin = new Thickness(20),
                Content = absoluteLayout
            };
            contentView.SizeChanged += OnContentViewSizeChanged;

            Title = "Chessboard demo";
            Content = contentView;
        }

        void OnContentViewSizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = sender as ContentView;
            double boardSize = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSize;
            absoluteLayout.HeightRequest = boardSize;
        }
    }
}

