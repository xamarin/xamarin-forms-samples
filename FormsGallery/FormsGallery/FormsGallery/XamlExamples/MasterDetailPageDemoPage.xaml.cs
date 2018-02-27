using System;
using System.Collections;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class MasterDetailPageDemoPage : MasterDetailPage
    {
        public MasterDetailPageDemoPage()
        {
            InitializeComponent();

            listView.SelectedItem = (listView.ItemsSource as IList)?[0];
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Show the detail page.
            IsPresented = false;
        }
    }
}