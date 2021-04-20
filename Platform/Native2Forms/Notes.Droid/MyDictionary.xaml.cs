using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDictionary : ResourceDictionary
    {
        public MyDictionary()
        {
            InitializeComponent();
        }
    }
}
