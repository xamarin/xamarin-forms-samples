using System;
using Xamarin.Forms;

namespace GameOfLife
{
    class LifeCell : BoxView
    {
        bool isAlive;

        public event EventHandler Tapped;

        public LifeCell()
        {
            BackgroundColor = Color.White;

            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (sender, args) =>
            {
                Tapped?.Invoke(this, EventArgs.Empty);
            };
            GestureRecognizers.Add(tapGesture);
        }

        public int Col { set; get; }

        public int Row { set; get; }

        public bool IsAlive
        {
            set
            {
                if (isAlive != value)
                {
                    isAlive = value;
                    BackgroundColor = isAlive ? Color.Black : Color.White;
                }
            }
            get
            {
                return isAlive;
            }
        }
    }
}
