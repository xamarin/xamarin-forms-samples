using System;
using System.Linq;
using Xamarin.Forms;
using Xaminals.Data;

namespace Xaminals.Views
{
    [QueryProperty("Name", "name")]
    public partial class ElephantDetailPage : ContentPage
    {
        public string Name
        {
            set
            {
                BindingContext = ElephantData.Elephants.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
            }
        }

        public ElephantDetailPage()
        {
            InitializeComponent();
        }
    }
}
