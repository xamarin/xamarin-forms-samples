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
			List<Page> listOfPages = new List<Page> () {
				new CalculatorGridXAML (),
				new CalculatorGridCode (),
				new MonkeyMoneyXaml (),
				new MonkeyMoneyCode (),
				new MonkeyMusic (),
				new MonkeyMusicCode (),
				new AbsoluteLayoutDemoXaml (),
				new AbsoluteLayoutDemoCode (),
				new RelativeLayoutDemo (),
				new RelativeLayoutDemoCode (),
				new RelativeLayoutExploration (),
				new RelativeLayoutExplorationCode (),
				new AbsoluteLayoutExploration (),
				new AbsoluteLayoutExplorationCode (),
				new GridExploration (),
				new StackLayoutDemo (),
				new StackLayoutDemoCode (),
				new LabelGridXaml (),
				new LabelGridCode (),
				new ScrollingDemoXAML (),
				new ScrollingDemoCode ()
			};

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