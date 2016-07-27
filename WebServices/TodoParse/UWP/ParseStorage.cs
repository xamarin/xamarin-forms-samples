using Parse;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TodoParse.UWP
{
	public class ParseStorage : IParseStorage
	{
		static ParseStorage todoServiceInstance = new ParseStorage ();

		public static ParseStorage Default { get { return todoServiceInstance; } }

		public List<TodoItem> Items { get; private set; }

		protected ParseStorage ()
		{
			Items = new List<TodoItem> ();

			// https://parse.com/apps/YOUR_APP_NAME/edit#app_keys
			// ApplicationId, Windows/.NET/Client key
			//ParseClient.Initialize ("APPLICATION_ID", ".NET_KEY");
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
		}

		ParseObject ToParseObject (TodoItem todo)
		{
			var po = new ParseObject ("TodoItem");
			if (todo.ID != string.Empty)
            {
                po.ObjectId = todo.ID;
            }
			po ["Title"] = todo.Name;
			po ["Description"] = todo.Notes;
			po ["IsDone"] = todo.Done;

			return po;
		}

		static TodoItem FromParseObject (ParseObject po)
		{
			var t = new TodoItem ();
			t.ID = po.ObjectId;
			t.Name = Convert.ToString (po ["Title"]);
			t.Notes = Convert.ToString (po ["Description"]);
			t.Done = Convert.ToBoolean (po ["IsDone"]);
			return t;
		}

		async public Task<List<TodoItem>> RefreshDataAsync ()
		{
			var query = ParseObject.GetQuery ("TodoItem");
			var results = await query.FindAsync ();

			var Items = new List<TodoItem> ();
			foreach (var item in results) {
				Items.Add (FromParseObject (item));
			}

			return Items;
		}

		public async Task SaveTodoItemAsync (TodoItem todoItem)
		{
			try {
				await ToParseObject (todoItem).SaveAsync ();
			} catch (Exception e) {
				Debug.WriteLine (@"				ERROR {0}", e.Message);
			}
		}

		public async Task DeleteTodoItemAsync (TodoItem item)
		{
			try {
				await ToParseObject (item).DeleteAsync ();
			} catch (Exception e) {
				Debug.WriteLine (@"				ERROR {0}", e.Message);
			}
		}
	}
}
