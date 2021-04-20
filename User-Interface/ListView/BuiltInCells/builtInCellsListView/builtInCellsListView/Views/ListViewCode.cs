using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace builtInCellsListView
{
	public class ListViewCode : ContentPage
	{
		private ObservableCollection<VeggieModel> veggies { get; set; }
		public ListViewCode ()
		{
			ListView listView = new ListView ();

            //TODO - uncomment the region for the built-in cell type you'd like to see
            //#region textCell
            //lstView.ItemTemplate = new DataTemplate (typeof(TextCell));
            //lstView.ItemTemplate.SetBinding (TextCell.TextProperty, "name");
            //lstView.ItemTemplate.SetBinding (TextCell.DetailProperty, "comment");
            //#endregion

            #region imageCell
            listView.ItemTemplate = new DataTemplate(typeof(ImageCell));
            listView.ItemTemplate.SetBinding(ImageCell.TextProperty, "name");
            listView.ItemTemplate.SetBinding(ImageCell.DetailProperty, "comment");
            listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "image");
            #endregion

            //#region switchCell
            //lstView.ItemTemplate = new DataTemplate(typeof(SwitchCell));
            //lstView.ItemTemplate.SetBinding(SwitchCell.TextProperty, "name");
            //lstView.ItemTemplate.SetBinding(SwitchCell.OnProperty, "isReallyAVeggie");
            //#endregion

            /*#region entryCell
			lstView.ItemTemplate = new DataTemplate(typeof(EntryCell));
			lstView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "name");
			lstView.ItemTemplate.SetBinding(EntryCell.TextProperty, "comment");
			#endregion*/

            listView.ItemsSource = Constants.Veggies;
            Content = listView;
        }
	}
}


