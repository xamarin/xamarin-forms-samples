using CardViewDemo.Services;
using System.ComponentModel;
using Xamarin.Forms;

namespace CardViewDemo
{
    [DesignTimeVisible(true)]
    public partial class CardViewMvvmPage : ContentPage
    {
        public CardViewMvvmPage()
        {
            InitializeComponent();
            BindingContext = DataService.GetPersonCollection();
        }
    }
}