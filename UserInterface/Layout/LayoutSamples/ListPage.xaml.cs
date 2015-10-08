using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
			List<Page> listOfPages = new List<Page> ();
			listOfPages.Add(new MonkeyMoneyXaml ());
			listOfPages.Add (new MonkeyMoneyCode ());
			listOfPages.Add (new MonkeyMusic ());
			listOfPages.Add (new MonkeyMusicCode ());
			listOfPages.Add (new AbsoluteLayoutDemoXaml ());
			listOfPages.Add (new AbsoluteLayoutDemoCode ());
			listOfPages.Add (new RelativeLayoutDemo ());
			listOfPages.Add (new RelativeLayoutDemoCode ());
			listOfPages.Add (new RelativeLayoutExploration ());
			listOfPages.Add (new RelativeLayoutExplorationCode ());
			listOfPages.Add (new AbsoluteLayoutExplorationCode ());
			listOfPages.Add (new AbsoluteLayoutExploration ());
			listOfPages.Add (new GridExploration ());
			listOfPages.Add (new StackLayoutDemo ());
			listOfPages.Add (new StackLayoutDemoCode ());
			listOfPages.Add (new LabelGridXaml ());
			listOfPages.Add (new LabelGridCode ());
			listOfPages.Add (new ScrollingDemoXAML ());
			listOfPages.Add (new ScrollingDemoCode ());

			listPages.ItemsSource = listOfPages;
			listPages.ItemSelected += ListPages_ItemSelected;
		}

		void ListPages_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				this.Navigation.PushAsync ((Page)e.SelectedItem);
			}
			listPages.SelectedItem = null;
		}
	}
}