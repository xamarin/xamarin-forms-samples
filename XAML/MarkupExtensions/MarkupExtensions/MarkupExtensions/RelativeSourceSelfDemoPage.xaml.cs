using Xamarin.Forms;

namespace MarkupExtensions
{
    public partial class RelativeSourceSelfDemoPage : ContentPage
    {
        public Person Person { get; } = new Person
        {
            Forename = "John",
            Surname = "Doe"
        };

        public RelativeSourceSelfDemoPage()
        {
            InitializeComponent();
        }
    }
}
