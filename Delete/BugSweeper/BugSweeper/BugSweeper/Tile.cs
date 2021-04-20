#define FIX_UWP_DOUBLE_TAPS   // Double-taps don't work well on UWP as of 2.3.0
#define FIX_UWP_NULL_CONTENT  // Set Content of Frame to null doesn't work in UWP as of 2.3.0

using System;
using System.Reflection;
using Xamarin.Forms;

namespace BugSweeper
{
    enum TileStatus
    {
        Hidden,
        Flagged,
        Exposed
    }

    class Tile : Frame
    {
        TileStatus tileStatus = TileStatus.Hidden;
        Label label;
        Image flagImage, bugImage;
        static ImageSource flagImageSource;
        static ImageSource bugImageSource;
        bool doNotFireEvent;

        public event EventHandler<TileStatus> TileStatusChanged;

        static Tile()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            flagImageSource = ImageSource.FromResource("BugSweeper.Images.Xamarin120.png", assembly);
            bugImageSource = ImageSource.FromResource("BugSweeper.Images.RedBug.png", assembly);
        }

        public Tile(int row, int col)
        {
            this.Row = row;
            this.Col = col;

            this.BackgroundColor = Color.Yellow;
            this.OutlineColor = Color.Blue;
            this.Padding = 2;

            label = new Label {
                Text = " ",
                TextColor = Color.Yellow,
                BackgroundColor = Color.Blue,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };

            flagImage = new Image {
                Source = flagImageSource,

            };

            bugImage = new Image {
                Source = bugImageSource
            };

            TapGestureRecognizer singleTap = new TapGestureRecognizer {
                NumberOfTapsRequired = 1
            };
            singleTap.Tapped += OnSingleTap;
            this.GestureRecognizers.Add(singleTap);

#if FIX_UWP_DOUBLE_TAPS

            if (Device.RuntimePlatform != Device.UWP) {

#endif

                TapGestureRecognizer doubleTap = new TapGestureRecognizer {
                    NumberOfTapsRequired = 2
                };
                doubleTap.Tapped += OnDoubleTap;
                this.GestureRecognizers.Add(doubleTap);

#if FIX_UWP_DOUBLE_TAPS

            }

#endif

        }

        public int Row { private set; get; }

        public int Col { private set; get; }

        public bool IsBug { set; get; }

        public int SurroundingBugCount { set; get; }

        public TileStatus Status {
            set {
                if (tileStatus != value) {
                    tileStatus = value;

                    switch (tileStatus) {
                        case TileStatus.Hidden:
                            this.Content = null;

#if FIX_UWP_NULL_CONTENT

                            if (Device.RuntimePlatform == Device.UWP) {
                                this.Content = new Label { Text = " " };
                            }

#endif
                            break;

                        case TileStatus.Flagged:
                            this.Content = flagImage;
                            break;

                        case TileStatus.Exposed:
                            if (this.IsBug) {
                                this.Content = bugImage;
                            } else {
                                this.Content = label;
                                label.Text =
                                        (this.SurroundingBugCount > 0) ?
                                            this.SurroundingBugCount.ToString() : " ";
                            }
                            break;
                    }

                    if (!doNotFireEvent && TileStatusChanged != null) {
                        TileStatusChanged(this, tileStatus);
                    }
                }
            }
            get {
                return tileStatus;
            }
        }

        // Does not fire TileStatusChanged events.
        public void Initialize()
        {
            doNotFireEvent = true;
            this.Status = TileStatus.Hidden;
            this.IsBug = false;
            this.SurroundingBugCount = 0;
            doNotFireEvent = false;
        }

#if FIX_UWP_DOUBLE_TAPS

        bool lastTapSingle;
        DateTime lastTapTime;

#endif

        void OnSingleTap(object sender, object args)
        {

#if FIX_UWP_DOUBLE_TAPS

            if (Device.RuntimePlatform == Device.UWP) {
                if (lastTapSingle && DateTime.Now - lastTapTime < TimeSpan.FromMilliseconds (500)) {
                    OnDoubleTap (sender, args);
                    lastTapSingle = false;
                } else {
                    lastTapTime = DateTime.Now;
                    lastTapSingle = true;
                }
        	}

#endif

            switch (this.Status) {
            case TileStatus.Hidden:
                this.Status = TileStatus.Flagged;
                break;

            case TileStatus.Flagged:
                this.Status = TileStatus.Hidden;
                break;

            case TileStatus.Exposed:
                    // Do nothing
                break;
            }
        }

        void OnDoubleTap (object sender, object args)
        {
            this.Status = TileStatus.Exposed;
        }
    }
}
