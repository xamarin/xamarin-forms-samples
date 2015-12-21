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

			var masterPageItems = new List<MasterPageItem> ();
			masterPageItems.Add (new MasterPageItem {
				Title = "Contacts",
				IconSource = "contacts.png",
				TargetType = typeof(ContactsPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "TodoList",
				IconSource = "todo.png",
				TargetType = typeof(TodoListPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Reminders",
				IconSource = "reminders.png",
				TargetType = typeof(ReminderPage)
			});

			listView.ItemsSource = masterPageItems;
		}
	}
}
