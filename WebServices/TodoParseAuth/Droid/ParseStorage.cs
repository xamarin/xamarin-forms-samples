using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace TodoParse.Droid
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
			po.ACL = new ParseACL (ParseUser.CurrentUser);

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
            var query = ParseObject.GetQuery("TodoItem");
			var results = await query.FindAsync ();

			var Items = new List<TodoItem> ();
			foreach (var item in results) {
				if (item.ACL != null)
                {
                    Items.Add(FromParseObject(item));
                }
			}

			return Items;
		}

		public async Task SaveTodoItemAsync (TodoItem todoItem)
		{
			try {
				await ToParseObject (todoItem).SaveAsync ();
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
			}
		}

		public async Task DeleteTodoItemAsync (TodoItem item)
		{
			try {
				await ToParseObject (item).DeleteAsync ();
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
			}
		}

		public async Task<bool> SignUpUserAsync (User user)
		{
			try {
				var parseUser = new ParseUser () {
					Username = user.Username,
					Password = user.Password,
					Email = user.Email
				};
				await parseUser.SignUpAsync ();
				// Sign up succeeded
				return true;
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
				return false;
			}
		}

		public async Task<bool> LoginUserAsync (User user)
		{
			try {
				await ParseUser.LogInAsync (user.Username, user.Password);
				// Login was successful
				return true;
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
				return false;
			}
		}

        public bool IsUserLoggedIn()
        {
            if (ParseUser.CurrentUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		public async Task LogoutAsync ()
		{
			try {
				await ParseUser.LogOutAsync ();
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
			}
		}
	}
}