using CardViewDemo.Services;
using Xamarin.Forms;

namespace CardViewDemo
{
    public partial class CardViewMvvmPage : ContentPage
    {
        public CardViewMvvmPage()
        {
            InitializeComponent();
            BindingContext = DataService.GetPersonCollection();
        }
    }
}