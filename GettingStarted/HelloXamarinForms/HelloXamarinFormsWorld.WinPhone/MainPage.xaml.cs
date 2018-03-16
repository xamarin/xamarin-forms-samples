using Microsoft.Phone.Controls;

using Xamarin.Forms;

namespace HelloXamarinFormsWorld.WinPhone
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            
			LoadApplication (new HelloXamarinFormsWorld.App ());
        }
    }
}
