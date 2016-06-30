using System;
using Xamarin.Forms;

namespace BugSweeper
{
    class Board : AbsoluteLayout
    {
        // Alternative sizes make the tiles a tad small.
        const int COLS = 9;         // 16
        const int ROWS = 9;         // 16
        const int BUGS = 10;        // 40

        Tile[,] tiles = new Tile[ROWS, COLS];
        int flaggedTileCount;
        bool isGameInProgress;              // on first tap
        bool isGameInitialized;             // on first double-tap
        bool isGameEnded;

        // Events to notify page.
        public event EventHandler GameStarted;
        public event EventHandler<bool> GameEnded;

        public Board()
        {
            for (int row = 0; row < ROWS; row++)
                for (int col = 0; col < COLS; col++)
                {
                    Tile tile = new Tile(row, col);
                    tile.TileStatusChanged += OnTileStatusChanged;
                    this.Children.Add(tile);
                    tiles[row, col] = tile;
                }

            SizeChanged += (sender, args) =>
                {
                    double tileWidth = this.Width / COLS;
                    double tileHeight = this.Height / ROWS;

                    foreach (Tile tile in tiles)
                    {
                        Rectangle bounds = new Rectangle(tile.Col * tileWidth,
                                                         tile.Row * tileHeight,
                                                         tileWidth, tileHeight);
                        AbsoluteLayout.SetLayoutBounds(tile, bounds);
                    }
                };

            NewGameInitialize();
        }

        public void NewGameInitialize()
        {
            // Clear all the tiles.
            foreach (Tile tile in tiles)
                tile.Initialize();

            isGameInProgress = false;
            isGameInitialized = false;
            isGameEnded = false;
            this.FlaggedTileCount = 0;
        }

        public int FlaggedTileCount
        {
            set
            {
                if (flaggedTileCount != value)
                {
                    flaggedTileCount = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return flaggedTileCount;
            }
        }

        public int BugCount
        {
            get
            {
                return BUGS;
            }
        }

        
        // Not called until the first tile is double-tapped.
        void DefineNewBoard(int tappedRow, int tappedCol)
        {
            // Begin the assignment of bugs.
            Random random = new Random();
            int bugCount = 0;

            while (bugCount < BUGS)
            {
                // Get random row and column.
                int row = random.Next(ROWS);
                int col = random.Next(COLS);

                // Skip it if it's already a bug.
                if (tiles[row, col].IsBug)
                {
                    continue;
                }

                // Avoid the tappedRow & Col & surrounding ones.
                if (row >= tappedRow - 1 &&
                    row <= tappedRow + 1 &&
                    col >= tappedCol - 1 &&
                    col <= tappedCol + 1)
                {
                    continue;
                }

                // It's a bug!
                tiles[row, col].IsBug = true;

                // Calculate the surrounding bug count.
                CycleThroughNeighbors(row, col,
                    (neighborRow, neighborCol) =>
                    {
                        ++tiles[neighborRow, neighborCol].SurroundingBugCount;
                    });

                bugCount++;
            }
        }

        void CycleThroughNeighbors(int row, int col, Action<int, int> callback)
        {
            int minRow = Math.Max(0, row - 1);
            int maxRow = Math.Min(ROWS - 1, row + 1);
            int minCol = Math.Max(0, col - 1);
            int maxCol = Math.Min(COLS - 1, col + 1);

            for (int neighborRow = minRow; neighborRow <= maxRow; neighborRow++)
                for (int neighborCol = minCol; neighborCol <= maxCol; neighborCol++)
                {
                    if (neighborRow != row || neighborCol != col)
                        callback(neighborRow, neighborCol);
                }
        }

        void OnTileStatusChanged(object sender, TileStatus tileStatus)
        {
            if (isGameEnded)
                return;

            // With a first tile tapped, the game is now in progress.
            if (!isGameInProgress)
            {
                isGameInProgress = true;

                // Fire the GameStarted event.
                if (GameStarted != null)
                {
                    GameStarted(this, EventArgs.Empty);
                }
            }

            // Update the "flagged" bug count before checking for a loss.
            int flaggedCount = 0;

            foreach (Tile tile in tiles)
                if (tile.Status == TileStatus.Flagged)
                    flaggedCount++;

            this.FlaggedTileCount = flaggedCount;

            // Get the tile whose status has changed.
            Tile changedTile = (Tile)sender;

            // If it's exposed, some actions are required.
            if (tileStatus == TileStatus.Exposed)
            {
                if (!isGameInitialized)
                {
                    DefineNewBoard(changedTile.Row, changedTile.Col);
                    isGameInitialized = true;
                }

                if (changedTile.IsBug)
                {
                    isGameInProgress = false;
                    isGameEnded = true;

                    // Fire the GameEnded event!
                    if (GameEnded != null)
                    {
                        GameEnded(this, false);
                    }
                    return;
                }

                // Auto expose for zero surrounding bugs.
                if (changedTile.SurroundingBugCount == 0)
                {
                    CycleThroughNeighbors(changedTile.Row, changedTile.Col,
                        (neighborRow, neighborCol) =>
                        {
                            // Expose all the neighbors.
                            tiles[neighborRow, neighborCol].Status = TileStatus.Exposed;
                        });
                }
            }

            // Check for a win.
            bool hasWon = true;

            foreach (Tile til in tiles)
            {
                if (til.IsBug && til.Status != TileStatus.Flagged)
                    hasWon = false;

                if (!til.IsBug && til.Status != TileStatus.Exposed)
                    hasWon = false;
            }

            // If there's a win, celebrate!
            if (hasWon)
            {
                isGameInProgress = false;
                isGameEnded = true;

                // Fire the GameEnded event!
                if (GameEnded != null)
                {
                    GameEnded(this, true);
                }
                return;
            }
        }
    }
}
