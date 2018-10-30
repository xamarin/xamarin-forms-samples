using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace XamarinFormsWPF.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new XamarinFormsWPF.App());
        }
    }
}
