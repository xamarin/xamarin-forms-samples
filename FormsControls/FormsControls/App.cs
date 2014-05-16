using System;
using Xamarin.Forms;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace FormsControls
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new MainList ());
		}
	}

	public class MainList : ContentPage
	{
		public MainList ()
		{
			var list = new ListView {
				ItemTemplate = new DataTemplate (typeof(TextCell)) {
					Bindings = {
						{ TextCell.TextProperty, new Binding ("Name") }
					}
				},

				GroupDisplayBinding = new Binding ("Title"),
				IsGroupingEnabled = true,
				ItemSource = SetupDemos (),
			};

			list.ItemTapped += (sender, e) => {
				var demo = (Demo)e.Data;
				Navigation.Push ((Page)Activator.CreateInstance (demo.Screen));
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { list }		
			};
		}

		ObservableCollection<DemoGroup> SetupDemos ()
		{
			var allDemos = new ObservableCollection<DemoGroup> ();
			foreach (var demo in demos) {
				AddDemo (allDemos, demo);
			}
			return allDemos;
		}

		void AddDemo (ObservableCollection<DemoGroup> demoGroups, Demo demo)
		{
			var demoGroup = demoGroups.FirstOrDefault (d => d.Title == demo.CategoryTitle);

			// If the list group does not exist, we create it.
			if (demoGroup == null) {
				demoGroup = new DemoGroup (demo.CategoryTitle);
				demoGroup.Add (demo);
				demoGroups.Add (demoGroup);
			} else { // If the group does exist, we simply add the demo to the existing group.
				demoGroup.Add (demo);
			}
		}

		// ListView element on the main nav page.
		class Demo
		{
			public string Name { get; private set; }
			public string CategoryTitle { get; private set; }
			public Type Screen { get; private set; }

			public Demo (string categoryTitle, Type screen)
			{
				Name = screen.Name;
				Screen = screen;
				CategoryTitle = categoryTitle;
			}
		}

		// Group of ListView elements on the main nav page.
		class DemoGroup : ObservableCollection<Demo>
		{
			public string Title { get; private set; }

			public DemoGroup (string title)
			{
				Title = title;
			}
		}

		// Content for our ListView
		readonly List<Demo> demos = new List<Demo> {
			new Demo ("Form Controls", typeof (Labels)),
			new Demo ("Form Controls", typeof (Entries)),
			new Demo ("Content Controls", typeof (Images)),

		};
	}
}