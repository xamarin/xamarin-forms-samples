using System.Windows.Input;
using Xamarin.Forms;

namespace DragAndDropGesture
{
    public class CustomDataPackageViewModel
    {
        Square draggedSquare;

        public ICommand DragStartingCommand => new Command<Square>(RegisterDragData);
        public ICommand DropCommand => new Command<Square>(ProcessDrop);

        void RegisterDragData(Square square)
        {
            draggedSquare = square;
        }

        void ProcessDrop(Square square)
        {
            if (square.Area.Equals(draggedSquare.Area))
            {
                MessagingCenter.Send<CustomDataPackageViewModel, string>(this, "Correct", "Congratulations!");
            }
            else
            {
                MessagingCenter.Send<CustomDataPackageViewModel, string>(this, "Incorrect", "Try again.");
            }
        }
    }
}
