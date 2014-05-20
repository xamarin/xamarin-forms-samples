using System;
using Xamarin.Forms;
using System.Linq;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory
{
	public class EmployeeListView : ContentPage
	{
		private FavoritesViewModel viewModel;
		private IFavoritesRepository favoritesRepository;
		private ListView listView;

		public EmployeeListView ()
		{
			Title = "Employee Directory";

			var toolBarItem = new ToolbarItem ("?", "Search.png", () => {
				var search = new SearchListXaml ();
				Navigation.Push (search);
			}, 0, 0);

			ToolbarItems.Add (toolBarItem);

			listView = new ListView () {
				IsGroupingEnabled = true
			};

			listView.GroupHeaderTemplate = new DataTemplate (typeof(GroupHeaderTemplate));
			listView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
			listView.ItemTapped += OnItemSelected;
			Content = listView;
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime))
				await Navigation.PushModal (new LoginView ());

			favoritesRepository = await XmlFavoritesRepository.OpenIsolatedStorage ("XamarinFavorites.xml");

			if (favoritesRepository.GetAll ().Count () == 0)
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");

			viewModel = new FavoritesViewModel (favoritesRepository, false);

			listView.ItemSource = viewModel.Groups;
		}

		public void OnItemSelected (object sender, EventArg<object> e)
		{
			var p = ((EventArg<object>)e).Data as Person;
			var selectedEmployee = new EmployeeXaml ();

			var person = new PersonViewModel (p, favoritesRepository);
			selectedEmployee.BindingContext = person;
			Navigation.Push (selectedEmployee);
		}

		public class GroupHeaderTemplate : ViewCell
		{
			public GroupHeaderTemplate ()
			{
				var label = new Label() {
					YAlign = TextAlignment.Center
				};

				label.SetBinding (Label.TextProperty, "Title");
				View = label;
			}
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate()
			{
				var photo = new Image {
					HeightRequest = 44.0,
					WidthRequest = 44.0
				};

				photo.SetBinding(Image.SourceProperty, "LocalImagePath");

				var nameLabel  = new Label() { 
					YAlign = TextAlignment.Center,
					Font = Font.BoldSystemFontOfSize(NamedSize.Medium)
				};

				nameLabel.SetBinding (Label.TextProperty, "Name");

				var titleLabel  = new Label() { 
					YAlign = TextAlignment.Center,
					Font = Font.BoldSystemFontOfSize(NamedSize.Micro)
				};

				titleLabel.SetBinding (Label.TextProperty, "Title");

				var information = new StackLayout {
					Padding = new Thickness(5.0, 0.0, 0.0, 0.0),
					VerticalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Vertical,
					Children = { nameLabel, titleLabel }
				};

				View = new StackLayout { 
					Orientation = StackOrientation.Horizontal,
					Children = { photo, information }
				};
			}
		}
	}
}