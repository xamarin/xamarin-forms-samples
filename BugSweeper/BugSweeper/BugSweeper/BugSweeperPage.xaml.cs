#define FIX_WINPHONE_BUTTON         // IsEnabled = false doesn't disable button

#pragma warning disable 4014        // for non-await'ed async call

using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BugSweeper
{
    public partial class BugSweeperPage : ContentPage
    {
        const string timeFormat = @"%m\:ss";

        bool isGameInProgress;
        DateTime gameStartTime;

        public BugSweeperPage()
        {
            InitializeComponent();

            board.GameStarted += (sender, args) =>
                {
                    isGameInProgress = true;
                    gameStartTime = DateTime.Now;

                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        timeLabel.Text = (DateTime.Now - gameStartTime).ToString(timeFormat);
                        return isGameInProgress;
                    });
                };

            board.GameEnded += (sender, hasWon) =>
                {
                    isGameInProgress = false;

                    if (hasWon)
                    {
                        DisplayWonAnimation();
                    }
                    else
                    {
                        DisplayLostAnimation();
                    }
                };

            PrepareForNewGame();
        }

        void PrepareForNewGame()
        {
            board.NewGameInitialize();

            congratulationsText.IsVisible = false;
            consolationText.IsVisible = false;
            playAgainButton.IsVisible = false;
            playAgainButton.IsEnabled = false;

            timeLabel.Text = new TimeSpan().ToString(timeFormat);
            isGameInProgress = false;
        }

        void OnMainContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double width = contentView.Width;
            double height = contentView.Height;

            bool isLandscape = width > height;

            if (isLandscape)
            {
                mainGrid.RowDefinitions[0].Height = 0;
                mainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(textStack, 1);
                Grid.SetColumn(textStack, 0);
            }
            else // portrait
            {
                mainGrid.RowDefinitions[0].Height = new GridLength(3, GridUnitType.Star);
                mainGrid.RowDefinitions[1].Height = new GridLength(5, GridUnitType.Star);

                mainGrid.ColumnDefinitions[0].Width = 0;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(textStack, 0);
                Grid.SetColumn(textStack, 1);
            }
        }

        // Maintains a square aspect ratio for the board.
        void OnBoardContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double width = contentView.Width;
            double height = contentView.Height;
            double dimension = Math.Min(width, height);
            double horzPadding = (width - dimension) / 2;
            double vertPadding = (height - dimension) / 2;
            contentView.Padding = new Thickness(horzPadding, vertPadding);
        }

        async void DisplayWonAnimation()
        {
            congratulationsText.Scale = 0;
            congratulationsText.IsVisible = true;

            // Because IsVisible has been false, the text might not have a size yet,
            //  in which case Measure will return a size.
            double congratulationsTextWidth = congratulationsText.Measure(Double.PositiveInfinity, Double.PositiveInfinity).Request.Width;

            congratulationsText.Rotation = 0;
            congratulationsText.RotateTo(3 * 360, 1000, Easing.CubicOut);

            double maxScale = 0.9 * board.Width / congratulationsTextWidth;
            await congratulationsText.ScaleTo(maxScale, 1000);

            foreach (View view in congratulationsText.Children)
            {
                view.Rotation = 0;
                view.RotateTo(180);
                await view.ScaleTo(3, 100);
                view.RotateTo(360);
                await view.ScaleTo(1, 100);
            }

            await DisplayPlayAgainButton();
        }

        async void DisplayLostAnimation()
        {
            consolationText.Scale = 0;
            consolationText.IsVisible = true;

            // (See above for rationale)
            double consolationTextWidth = consolationText.Measure(Double.PositiveInfinity, Double.PositiveInfinity).Request.Width;

            double maxScale = 0.9 * board.Width / consolationTextWidth;
            await consolationText.ScaleTo(maxScale, 1000);
            await Task.Delay(1000);
            await DisplayPlayAgainButton();
        }

        async Task DisplayPlayAgainButton()
        {
            playAgainButton.Scale = 0;
            playAgainButton.IsVisible = true;
            playAgainButton.IsEnabled = true;

            // (See above for rationale)
            double playAgainButtonWidth = playAgainButton.Measure(Double.PositiveInfinity, Double.PositiveInfinity).Request.Width;

            double maxScale = board.Width / playAgainButtonWidth;
            await playAgainButton.ScaleTo(maxScale, 1000, Easing.SpringOut);
        }

        void OnplayAgainButtonClicked(object sender, object EventArgs)
        {
#if FIX_WINPHONE_BUTTON

            if (Device.RuntimePlatform == Device.WinPhone && !((Button)sender).IsEnabled)
                return;

#endif
            PrepareForNewGame();
        }
    }
}
