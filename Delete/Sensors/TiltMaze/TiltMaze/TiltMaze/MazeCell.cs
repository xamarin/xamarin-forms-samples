namespace TiltMaze
{
    public struct MazeCell
    {
        public bool HasLeft { internal set; get; }

        public bool HasTop { internal set; get; }

        public bool HasRight { internal set; get; }

        public bool HasBottom { internal set; get; }

        public MazeCell(bool left, bool top, bool right, bool bottom) : this()
        {
            HasLeft = left;
            HasTop = top;
            HasRight = right;
            HasBottom = bottom;
        }
    }
}

