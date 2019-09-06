using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace builtInCellsListView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextCellXaml : ContentPage
    {
        public TextCellXaml()
        {
            InitializeComponent();
            listView.ItemsSource = Constants.Veggies;
        }
    }
}