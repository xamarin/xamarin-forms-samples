using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NotesView : ContentView
    {
        public NotesView()
        {
            InitializeComponent();
        }

       



        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MainPage.Current.OnListViewItemSelected(e.SelectedItem as Note);
        }
    }
}
