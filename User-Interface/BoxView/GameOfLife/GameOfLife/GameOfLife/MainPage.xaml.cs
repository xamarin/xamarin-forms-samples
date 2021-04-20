using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace GameOfLife
{
    public partial class MainPage : ContentPage
    {
        const int MaxCellSize = 30;     // includes cell spacing
        const int CellSpacing = 2;

        // Generating too many BoxView elements can impact performance, 
        //      particularly on iOS devices.
        const int MaxCellCount = 400;

        // Calculated during SizeChanged event 
        int cols;
        int rows;
        int cellSize;
        int xMargin;
        int yMargin;

        LifeGrid lifeGrid = new LifeGrid();
        bool isRunning;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnLayoutSizeChanged(object sender, EventArgs args)
        {
            Layout layout = sender as Layout;

            cols = (int)Math.Round(layout.Width / MaxCellSize);
            rows = (int)Math.Round(layout.Height / MaxCellSize);

            if (cols * rows > MaxCellCount)
            {
                cellSize = (int)Math.Sqrt((layout.Width * layout.Height) / MaxCellCount);
                cols = (int)(layout.Width / cellSize);
                rows = (int)(layout.Height / cellSize);
            }
            else
            {
                cellSize = (int)Math.Min(layout.Width / cols, layout.Height / rows);
            }

            xMargin = (int)((layout.Width - cols * cellSize) / 2);
            yMargin = (int)((layout.Height - rows * cellSize) / 2);

            if (cols > 0 && rows > 0)
            {
                lifeGrid.SetSize(cols, rows);
                UpdateLayout();
                UpdateLives();
            }
        }

        void UpdateLayout()
        {
            // TODO: Put up Activity Indicator


            int count = rows * cols;

            System.Diagnostics.Debug.WriteLine("Count = " + count);

            // Remove unneeded LifeCell children
            while (absoluteLayout.Children.Count > count)
            {
                absoluteLayout.Children.RemoveAt(0);
            }

            // Possibly add more LifeCell children
            while (absoluteLayout.Children.Count < count)
            {
                LifeCell lifeCell = new LifeCell();
                lifeCell.Tapped += OnTapGestureTapped;
                absoluteLayout.Children.Add(lifeCell);
            }

            int index = 0;

            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                {
                    LifeCell lifeCell = lifeCell = (LifeCell)absoluteLayout.Children[index];
                    lifeCell.Col = x;
                    lifeCell.Row = y;
                    lifeCell.IsAlive = lifeGrid.IsAlive(x, y);

                    Rectangle rect = new Rectangle(x * cellSize + xMargin + CellSpacing / 2,
                                                   y * cellSize + yMargin + CellSpacing / 2,
                                                   cellSize - CellSpacing,
                                                   cellSize - CellSpacing);

                    AbsoluteLayout.SetLayoutBounds(lifeCell, rect);
                    index++;
                }
        }

        void UpdateLives()
        {
            foreach (View view in absoluteLayout.Children)
            {
                LifeCell lifeCell = view as LifeCell;
                lifeCell.IsAlive = lifeGrid.IsAlive(lifeCell.Col, lifeCell.Row);
            }
        }

        void OnTapGestureTapped(object sender, EventArgs args)
        {
            LifeCell lifeCell = (LifeCell)sender;
            lifeCell.IsAlive ^= true;
            lifeGrid.SetStatus(lifeCell.Col, lifeCell.Row, lifeCell.IsAlive);
        }

        void OnRunButtonClicked(object sender, EventArgs args)
        {
            if (!isRunning)
            {
                runButton.Text = "Pause";
                isRunning = true;
                clearButton.IsEnabled = false;
                Device.StartTimer(TimeSpan.FromMilliseconds(250), OnTimerTick);
            }
            else
            {
                StopRunning();
            }
        }

        void StopRunning()
        {
            isRunning = false;
            runButton.Text = "Run!";
            clearButton.IsEnabled = true;
        }

        bool OnTimerTick()
        {
            if (isRunning)
            {
                bool isLifeLeft = lifeGrid.Tick();
                UpdateLives();

                if (!isLifeLeft)
                {
                    StopRunning();
                }
            }

            return isRunning;
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            lifeGrid.Clear();
            UpdateLives();
        }

        void OnAboutButtonClicked(object sender, EventArgs args)
        {
            aboutText.IsVisible = true;
        }

        async void OnHyperlinkTapped(object sender, EventArgs args)
        {
            Label label = (Label)sender;
            await Launcher.OpenAsync(label.Text);
        }

        private void OnCloseButtonClicked(object sender, EventArgs args)
        {
            aboutText.IsVisible = false;
        }
    }
}
