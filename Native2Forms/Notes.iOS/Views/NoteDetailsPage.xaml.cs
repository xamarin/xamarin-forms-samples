using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewHolder.TranslateTo(0, 0, 600, Easing.BounceIn);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            ViewHolder.TranslateTo(0, -2000, 300, Easing.BounceOut);
        }
    }
}
