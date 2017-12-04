using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class LifeGrid
    {
        // Changed to true for grid-wrapping logic
        const bool Wrap = false;

        // Internal structure for encapsulting integer cell coordinates
        // Keep this a structure for automatic equality comparison!
        struct Coordinate
        {
            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { private set; get; }

            public int Y { private set; get; }
        }

        // The current population is stored in two ways, 
        //  both of which are valid and consistent after every method call.

        // This is a List of the coordinates of living cells:
        List<Coordinate> coordinates = new List<Coordinate>();

        // This is an array for for performing the Tick algorithm efficiently:
        int cols = 10;
        int rows = 10;
        bool[,] grid = new bool[10, 10];

        public void SetSize(int cols, int rows)
        {
            if (cols <= 0 || rows <= 0)
                throw new ArgumentException("LifeGrid.SetSize: Arguments must be greater than zero");

            // If !Wrap, remove items from coordinates if X or Y greater than new cols and rows
            if (!Wrap)
            {
                List<Coordinate> removeList = new List<Coordinate>();
                foreach (Coordinate coordinate in coordinates)
                {
                    if (coordinate.X < 0 || coordinate.X >= cols ||
                        coordinate.Y < 0 || coordinate.Y >= rows)
                    {
                        removeList.Add(coordinate);
                    }
                }
                foreach (Coordinate coordinate in removeList)
                {
                    coordinates.Remove(coordinate);
                }
            }


            this.cols = cols;
            this.rows = rows;
            CreateGridArray();
        }

        public void SetStatus(int x, int y, bool isAlive)
        {
            Coordinate coordinate = new Coordinate(x, y);

            if (isAlive && !coordinates.Contains(coordinate))
            {
                coordinates.Add(coordinate);
            }
            if (!isAlive && coordinates.Contains(coordinate))
            {
                coordinates.Remove(coordinate);
            }

            CreateGridArray();
        }

        public bool IsAlive(int x, int y)
        {
            return grid[x, y];
        }

        public void Clear()
        {
            coordinates.Clear();
            CreateGridArray();
        }

        public bool Tick()
        {
            coordinates.Clear();

            if (grid == null)
                return false;

            for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)
            {
                int count = 0;

                for (int xi = x - 1; xi <= x + 1; xi++)
                for (int yi = y - 1; yi <= y + 1; yi++)
                {
                    if (Wrap)
                    {
                        count += grid[(xi + cols) % cols, (yi + rows) % rows] ? 1 : 0;
                    }
                    else
                    {
                        if (xi >= 0 && yi >= 0 && xi < cols && yi < rows)
                        {
                            count += grid[xi, yi] ? 1 : 0;
                        }
                    }
                }

                if (count == 3 || (count == 4 && grid[x, y]))
                {
                        // Modulo arithmetic is necessary when Wrap is true
                        coordinates.Add(new Coordinate(x % cols, y % rows));
                }
            }

            CreateGridArray();

            return coordinates.Count > 0;
        }

        void CreateGridArray()
        {
            if (rows <= 0 || cols <= 0)
            {
                grid = null;
                return;
            }

            grid = new bool[cols, rows];

            foreach (Coordinate coordinate in coordinates)
            {
                // Modulo arithmetic is necessary when Wrap is true
                grid[coordinate.X % cols, coordinate.Y % rows] = true;
            }
        }
    }
}
