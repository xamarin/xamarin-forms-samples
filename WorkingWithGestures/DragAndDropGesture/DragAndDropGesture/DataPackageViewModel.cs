using System.Windows.Input;
using Xamarin.Forms;

namespace DragAndDropGesture
{
    public class DataPackageViewModel
    {
        string dragData;

        public ICommand DragCommand => new Command<string>(RegisterDragData);
        public ICommand DropCommand => new Command(ProcessDrop);

        void RegisterDragData(string data)
        {
            dragData = data;
        }

        void ProcessDrop()
        {
            if (dragData.Equals("Cat"))
            {
                MessagingCenter.Send<DataPackageViewModel, string>(this, "Correct", "Congratulations!");
            }
            else if (dragData.Equals("Monkey"))
            {
                MessagingCenter.Send<DataPackageViewModel, string>(this, "Incorrect", "Try again.");
            }
        }
    }
}
