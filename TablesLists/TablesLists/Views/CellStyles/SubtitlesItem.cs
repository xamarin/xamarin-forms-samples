using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class SubtitlesItem :  PageViewBase
	{
		public SubtitlesItem (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
            if (Device.OS == TargetPlatform.WinPhone) {
                ListView.IsGroupingEnabled = true;
                ListView.GroupHeaderTemplate = new DataTemplate(typeof(HeaderTemplate));
            }
                
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.OS == TargetPlatform.WinPhone) {
                var menuItems = await ItemsRepository.OpenIsolatedStorage(ItemsSourceFile);
                var viewModel = new PageViewModel(menuItems);
                ListView.ItemsSource = viewModel.Groups;
            }
        }

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Large),
					YAlign = TextAlignment.Center
				};

				var subtitleLabel = new Label { 
					Font = Font.SystemFontOfSize (NamedSize.Micro),
					YAlign = TextAlignment.Center
				};
						
				titleLabel.SetBinding (Label.TextProperty, "Title");
				subtitleLabel.SetBinding (Label.TextProperty, "Subtitle");

				View = new StackLayout {
					Padding = new Thickness (15, 0, 0, 0),
					Children = { titleLabel, subtitleLabel }
				};

				Height = 50;
			}
		}
	}
}

