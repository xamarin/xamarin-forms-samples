using Xamarin.Forms;

namespace DIContainerDemo
{
    public class DragInfo
    {
        public long Id { get; private set; }
        public Point PressPoint { get; private set; }

        public DragInfo(long id, Point pressPoint)
        {
            Id = id;
            PressPoint = pressPoint;
        }
    }
}
