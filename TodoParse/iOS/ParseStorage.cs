using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace TodoParse.iOS
{
	public class ParseStorage : IParseStorage
	{
		static ParseStorage todoServiceInstance = new ParseStorage();
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
			var po = new ParseObject("Task");
			if (todo.ID != string.Empty)
				po.ObjectId = todo.ID;
			po["Title"] = todo.Name;
			po["Description"] = todo.Notes;
			po["IsDone"] = todo.Done;

			return po;
		}

		static TodoItem FromParseObject (ParseObject po)
		{
			var t = new TodoItem();
			t.ID = po.ObjectId;
			t.Name = Convert.ToString (po["Title"]);
			t.Notes = Convert.ToString (po["Description"]);
			t.Done = Convert.ToBoolean (po["IsDone"]);
			return t;
		}

		public static async Task<List<TodoItem>> GetAll () 
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var tl = new List<TodoItem> ();
			foreach (var t in ie) {
				tl.Add (FromParseObject (t));
			}

			return tl;
		}
			
		async public Task<List<TodoItem>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var Items = new List<TodoItem> ();
			foreach (var t in ie) {
				Items.Add (FromParseObject (t));
			}

			return Items;
		}

		public async Task SaveTodoItemAsync(TodoItem todoItem)
		{
			await ToParseObject(todoItem).SaveAsync();
		}

		public async Task<TodoItem> GetTodoItemAsync(string id)
		{
			var query = ParseObject.GetQuery("Task").WhereEqualTo("objectId", id);
			var t = await query.FirstAsync();
			return FromParseObject (t);
		}

		public async Task DeleteTodoItemAsync(TodoItem item)
		{
			try 
			{
				await ToParseObject(item).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}
	}
}
