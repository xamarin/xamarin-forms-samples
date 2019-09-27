using Xamarin.Forms;

namespace DataBindingDemos
{
    public partial class RelativeSourceSelfPage : ContentPage
    {
        public Person Person { get; } = new Person
        {
            Forename = "John",
            Surname = "Doe"
        };

        public RelativeSourceSelfPage()
        {
            InitializeComponent();
        }
    }
}
