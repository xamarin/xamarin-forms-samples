using System.Collections.Generic;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage ()
		{
			InitializeComponent ();

			var masterPageItems = new List<MasterPageItems> ();
			masterPageItems.Add (new MasterPageItems {
				Title = "Contacts",
				IconSource = "contacts.png",
				TargetType = typeof(ContactsPage)
			});
			masterPageItems.Add (new MasterPageItems {
				Title = "TodoList",
				IconSource = "todo.png",
				TargetType = typeof(TodoListPage)
			});
			masterPageItems.Add (new MasterPageItems {
				Title = "Reminders",
				IconSource = "reminders.png",
				TargetType = typeof(ReminderPage)
			});

			listView.ItemsSource = masterPageItems;
		}
	}
}
