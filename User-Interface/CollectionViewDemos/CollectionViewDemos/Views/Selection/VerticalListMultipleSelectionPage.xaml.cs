using System.Collections.Generic;
using System.Linq;
using CollectionViewDemos.Models;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListMultipleSelectionPage : ContentPage
    {
        public VerticalListMultipleSelectionPage()
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
            var previous = ToList(previousSelectedItems);
            var current = ToList(currentSelectedItems);
            previousSelectedItemLabel.Text = string.IsNullOrWhiteSpace(previous) ? "[none]" : previous;
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
        }

        static string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((Monkey)obj).Name);
        }
    }
}
