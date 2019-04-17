using Xamarin.Forms;

namespace FileUploader.CS
{
    public class FileUploaderPageCS : TabbedPage
    {
        public FileUploaderPageCS()
        {
            Children.Add(new ImageFileUploaderPageCS());
            Children.Add(new TextFileUploaderPageCS());
            Children.Add(new TextFileBrowserPageCS());
        }
    }
}

