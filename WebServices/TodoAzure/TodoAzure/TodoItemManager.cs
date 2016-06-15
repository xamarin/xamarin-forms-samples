// To add offline sync support: add the NuGet package WindowsAzure.MobileServices.SQLiteStore
// to all projects in the solution and uncomment the symbol definition OFFLINE_SYNC_ENABLED
// For Xamarin.iOS, also edit AppDelegate.cs and uncomment the call to SQLitePCL.CurrentPlatform.Init()
// For more information, see: http://go.microsoft.com/fwlink/?LinkId=620342 
//#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

namespace TodoAzure
{
	public partial class TodoItemManager
	{
		static TodoItemManager defaultInstance = new TodoItemManager ();
		MobileServiceClient client;

		#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<TodoItem> todoTable;


#else
		IMobileServiceTable<TodoItem> todoTable;
		#endif

		private TodoItemManager ()
		{
			this.client = new MobileServiceClient (
				Constants.ApplicationURL);

#if OFFLINE_SYNC_ENABLED
            var store = new MobileServiceSQLiteStore("localstore.db");
            store.DefineTable<TodoItem>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.todoTable = client.GetSyncTable<TodoItem>();
#else
			this.todoTable = client.GetTable<TodoItem> ();
#endif
		}

		public static TodoItemManager DefaultManager {
			get {
				return defaultInstance;
			}
			private set {
				defaultInstance = value;
			}
		}

		public MobileServiceClient CurrentClient {
			get { return client; }
		}

		public bool IsOfflineEnabled {
			get { return todoTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<TodoItem>; }
		}

		public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync (bool syncItems = false)
		{
			try {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                {
                    await this.SyncAsync();
                }
#endif
				IEnumerable<TodoItem> items = await todoTable
                    .Where (todoItem => !todoItem.Done)
                    .ToEnumerableAsync ();

				return new ObservableCollection<TodoItem> (items);
			} catch (MobileServiceInvalidOperationException msioe) {
				Debug.WriteLine (@"Invalid sync operation: {0}", msioe.Message);
			} catch (Exception e) {
				Debug.WriteLine (@"Sync error: {0}", e.Message);
			}
			return null;
		}

		public async Task SaveTaskAsync (TodoItem item)
		{
			if (item.Id == null) {
				await todoTable.InsertAsync (item);
			} else {
				await todoTable.UpdateAsync (item);
			}
		}

		#if OFFLINE_SYNC_ENABLED
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.todoTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allTodoItems",
                    this.todoTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
#endif
	}
}
