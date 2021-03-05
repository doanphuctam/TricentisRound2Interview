namespace Jaq {
    public class Box {
        public Box(int left, int top, int width, int height, double rank) {
            Left = left;
            Right = left+width;
            Top = top;
            Bottom = top + height;
            Width = width;
            Height = height;
            Rank = rank;
        }

        public int Id { get; }
        public int Left { get; }
        public int Right { get; }
        public int Top { get; }
        public int Bottom { get; }
        public int Width { get; }
        public int Height { get; }
        public double Rank { get; }
    }
}
