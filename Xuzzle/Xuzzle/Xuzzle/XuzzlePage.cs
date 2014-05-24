using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xuzzle
{
    class XuzzlePage : ContentPage
    {
        // Number of squares horizontally and vertically,
        //  but if you change it, modify font size as well.
        static readonly int NUM = 4;

        // Internal custom view for square
        class Square : ContentView
        {
            Label label;

            public Square(string text, int number)
            {
                // A Frame surrounding two Labels.
                label = new Label
                {
                    Text = text,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                Label tinyLabel = new Label
                {
                    Text = number.ToString(),
                    Font = Font.SystemFontOfSize(NamedSize.Micro),
                    HorizontalOptions = LayoutOptions.End
                };

                this.Padding = new Thickness(3);
                this.Content = new Frame
                {
                    OutlineColor = Color.Accent,
                    Padding = new Thickness(5, 10, 5, 0),
                    Content = new StackLayout
                    {
                        Spacing = 0,
                        Children = 
                        {
                            label,
                            tinyLabel,
                        }
                    }
                };

                // Don't let touch pass us by.
                this.BackgroundColor = Color.Transparent;
            }

            // Retain current Row and Col position.
            public int Row { set; get; }
            public int Col { set; get; }

            public Font Font
            {
                set { label.Font = value; }
            }
        }

        // Array of Square views, and empty row & column.
        Square[,] squares = new Square[NUM, NUM];
        int emptyRow = NUM - 1;
        int emptyCol = NUM - 1;

        StackLayout stackLayout;
        AbsoluteLayout absoluteLayout;
        double squareSize;
        bool isBusy;

        public XuzzlePage()
        {
            // AbsoluteLayout to host the squares.
            absoluteLayout = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            // Prepare for tap recognition
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer
            {
                TappedCallback = OnSquareTapped
            };

            // Create Square's for all the rows and columns.
            string text = "{XAMARIN.FORMS}";
            int index = 0;

            for (int row = 0; row < NUM; row++)
            {
                for (int col = 0; col < NUM; col++)
                {
                    // But skip the last one!
                    if (row == NUM - 1 && col == NUM - 1)
                        break;

                    // Create the Square with text.
                    Square square = new Square(text[index].ToString(), index + 1)
                    {
                        Row = row,
                        Col = col
                    };
                    square.GestureRecognizers.Add(tapGestureRecognizer);

                    // Add it to the array and the AbsoluteLayout
                    squares[row, col] = square;
                    absoluteLayout.Children.Add(square);
                    index++;
                }
            }

            // This is the "Randomize" button.
            Button button = new Button 
            {
                Text = "Randomize",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += OnRandomizeButtonClicked;

            // Put everything in a StackLayout.
            stackLayout = new StackLayout
            {
                Children = 
                {
                    button,
                    absoluteLayout
                }
            };
            stackLayout.SizeChanged += OnStackSizeChanged;

            // And set that to the content of the page.
            this.Padding = 
                new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
            this.Content = stackLayout;
        }

        void OnStackSizeChanged(object sender, EventArgs args)
        {
            double width = stackLayout.Width;
            double height = stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            // Orient StackLayout based on portrait/landscape mode.
            stackLayout.Orientation = (width < height) ? StackOrientation.Vertical : 
                                                         StackOrientation.Horizontal;

            // Calculate Square size and position based on stack size.
            squareSize = Math.Min(width, height) / NUM;
            absoluteLayout.WidthRequest = NUM * squareSize;
            absoluteLayout.HeightRequest = NUM * squareSize;
            Font font = Font.BoldSystemFontOfSize(0.4 * squareSize);

            foreach (View view in absoluteLayout.Children)
            {
                Square square = (Square)view;
                square.Font = font;

                AbsoluteLayout.SetLayoutBounds(square,
                    new Rectangle(square.Col * squareSize, 
                                  square.Row * squareSize, 
                                  squareSize, 
                                  squareSize));
            }
        }

        async void OnSquareTapped(View view, object args)
        {
            if (isBusy)
                return;

            isBusy = true;
            Square tappedSquare = (Square)view;
            await ShiftIntoEmpty (tappedSquare.Row, tappedSquare.Col);
            isBusy = false;
        }

        async Task ShiftIntoEmpty(int tappedRow, int tappedCol, uint length = 100)
        {
            // Shift columns.
            if (tappedRow == emptyRow && tappedCol != emptyCol)
            {
                int inc = Math.Sign(tappedCol - emptyCol);
                int begCol = emptyCol + inc;
                int endCol = tappedCol + inc;

                for (int col = begCol; col != endCol; col += inc)
                {
                    await AnimateSquare (emptyRow, col, emptyRow, emptyCol, length);
                }
            }
            // Shift rows.
            else if (tappedCol == emptyCol && tappedRow != emptyRow)
            {
                int inc = Math.Sign(tappedRow - emptyRow);
                int begRow = emptyRow + inc;
                int endRow = tappedRow + inc;

                for (int row = begRow; row != endRow; row += inc)
                {
                    await AnimateSquare (row, emptyCol, emptyRow, emptyCol, length);
                }
            }
        }

        async Task AnimateSquare(int row, int col, int newRow, int newCol, uint length)
        {
            // The Square to be animated.
            Square animaSquare = squares[row, col];

            // The destination rectangle.
            Rectangle rect = new Rectangle(squareSize * emptyCol,
                                           squareSize * emptyRow,
                                           squareSize,
                                           squareSize);

            // This is the actual animation call.
            await animaSquare.LayoutTo(rect, length);

            // Set several variables and properties for new layout.
            squares[newRow, newCol] = animaSquare;
            animaSquare.Row = newRow;
            animaSquare.Col = newCol;
            squares[row, col] = null;
            emptyRow = row;
            emptyCol = col;
        }

        async void OnRandomizeButtonClicked (object sender, EventArgs args)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            Random rand = new Random ();

            // Simulate some fast crazy taps.
            for (int i = 0; i < 100; i++)
            {
                await ShiftIntoEmpty (rand.Next(NUM), emptyCol, 25);
                await ShiftIntoEmpty (emptyRow, rand.Next(NUM), 25);
            }
            button.IsEnabled = true;
        }
    }
}
