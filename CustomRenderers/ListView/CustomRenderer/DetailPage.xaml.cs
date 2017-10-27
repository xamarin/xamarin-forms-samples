using System;
using Xamarin.Forms;

namespace CustomRenderer
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(object detail)
        {
            InitializeComponent();

            if (detail is string)
            {
                detailLabel.Text = detail as string;
            }
            else if (detail is DataSource)
            {
                detailLabel.Text = (detail as DataSource).Name;
            }
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
