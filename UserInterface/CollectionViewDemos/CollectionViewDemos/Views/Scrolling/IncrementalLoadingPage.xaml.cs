using System;
using System.Diagnostics;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class IncrementalLoadingPage : ContentPage
    {
        int itemCount = 10;
        const int MaximumItemCount = 50;
        const int PageSize = 10;
        AnimalsViewModel viewModel;

        public IncrementalLoadingPage()
        {
            InitializeComponent();
            viewModel = new AnimalsViewModel();
            BindingContext = viewModel;
        }

        void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
        {
            switch (itemCount)
            {
                case 10:
                    viewModel.AddCats();
                    break;
                case 20:
                    viewModel.AddDogs();
                    break;
                case 30:
                    viewModel.AddElephants();
                    break;
                case 40:
                    viewModel.AddMonkeys();
                    break;
            }

            if (itemCount < MaximumItemCount)
            {
                itemCount += PageSize;
            }

            Debug.WriteLine("Count: " + itemCount);
        }
    }
}
