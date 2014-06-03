using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class DateList : PageViewBase
	{
		public DateList (string itemsSourceFile, string title) : base (itemsSourceFile, title)
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
			private const int imageSize = 58;

			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Device.OS == TargetPlatform.WinPhone ? Font.SystemFontOfSize (NamedSize.Medium) : 
                        Font.SystemFontOfSize (NamedSize.Large)
				};

				var dateLabel = new Label {
                    Font = Device.OS == TargetPlatform.WinPhone ? Font.BoldSystemFontOfSize(NamedSize.Micro) :
                        Font.BoldSystemFontOfSize(NamedSize.Medium),
					TextColor = Color.Black,
					XAlign = TextAlignment.Center,
					LineBreakMode = LineBreakMode.WordWrap
				};

				dateLabel.SetBinding (Label.TextProperty, "Subtitle");
				titleLabel.SetBinding (Label.TextProperty, "Title");

				var image = new Image { 
					Source = Device.OS == TargetPlatform.WinPhone ? "Images/Calendar.png" : "Calendar.png",
					WidthRequest = imageSize,
					HeightRequest = imageSize
				};

				var absoluteLayout = new AbsoluteLayout {
					HorizontalOptions = LayoutOptions.Center
				};

				absoluteLayout.Children.Add (image, new Point (0, 0));
                absoluteLayout.Children.Add(dateLabel, Device.OS == TargetPlatform.WinPhone ? new Point(7, 17) : 
                    new Point (3, 17));

				View = new StackLayout {
					Orientation = StackOrientation.Horizontal,
                    Padding = Device.OS == TargetPlatform.WinPhone ? new Thickness(10, 10, 120, 10) : 
                        new Thickness(10, 10, 60, 10),
					Children = { absoluteLayout, titleLabel }
				};
			}
		}
	}
}

