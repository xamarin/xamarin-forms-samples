using System.Collections.Generic;
using System.Linq;
using CollectionViewDemos.Models;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListSingleSelectionPage : ContentPage
    {
        public VerticalListSingleSelectionPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
            UpdateSelectionData(Enumerable.Empty<Monkey>(), Enumerable.Empty<Monkey>());
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            string previous = (previousSelectedItems.FirstOrDefault() as Monkey)?.Name;
            string current = (currentSelectedItems.FirstOrDefault() as Monkey)?.Name;
            previousSelectedItemLabel.Text = string.IsNullOrWhiteSpace(previous) ? "[none]" : previous;
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
        }
    }
}
