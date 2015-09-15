using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;

namespace TodoAWSSimpleDB
{
	public class SimpleDBStorage : ISimpleDBStorage
	{
		AmazonSimpleDBClient client;
		string tableName = "TodoTest";

		public List<TodoItem> Items { get; private set; }

		public SimpleDBStorage ()
		{
			var credentials = new CognitoAWSCredentials (
				                  Constants.CognitoIdentityPoolId, 
				                  RegionEndpoint.USEast1);
			var config = new AmazonSimpleDBConfig ();
			config.RegionEndpoint = RegionEndpoint.USWest2;
			client = new AmazonSimpleDBClient (credentials, config);

			Items = new List<TodoItem> ();
			SetupDomain ();
		}

		async void SetupDomain ()
		{
			var domainExists = await IsExistingDomain ();
            if (!domainExists) {
                await CreateDomain();
            }
		}

		async Task<bool> IsExistingDomain ()
		{
			try {
				var response = await client.ListDomainsAsync (new ListDomainsRequest ());
				foreach (var domain in response.DomainNames) {
                    if (domain == tableName) {
                        return true;
                    }
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
			return false;
		}

		async Task CreateDomain ()
		{
			try {
				await client.CreateDomainAsync (new CreateDomainRequest { DomainName = tableName });
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

		List<Amazon.SimpleDB.Model.Attribute> ToSimpleDBAttributes (TodoItem item)
		{
			return new List<Amazon.SimpleDB.Model.Attribute> () {
				new Amazon.SimpleDB.Model.Attribute () {
					Name = "Name",
					Value = item.Name
				},
				new Amazon.SimpleDB.Model.Attribute () {
					Name = "Notes",
					Value = item.Notes
				},
				new Amazon.SimpleDB.Model.Attribute () {
					Name = "Done",
					Value = item.Done.ToString ()
				},
			};
		}

		List<ReplaceableAttribute> ToSimpleDBReplaceableAttributes (TodoItem item)
		{
			return new List<ReplaceableAttribute> () {
				new ReplaceableAttribute () {
					Name = "Name",
					Value = item.Name,
					Replace = true
				},
				new ReplaceableAttribute () {
					Name = "Notes",
					Value = item.Notes,
					Replace = true
				},
				new ReplaceableAttribute () {
					Name = "Done",
					Value = item.Done.ToString (),
					Replace = true
				}
			};
		}

		TodoItem FromSimpleDBAttributes (List<Amazon.SimpleDB.Model.Attribute> attributeList, string id)
		{
			var todoItem = new TodoItem ();
			todoItem.ID = id;
			todoItem.Name = attributeList.Where (attr => attr.Name == "Name").FirstOrDefault ().Value;
			todoItem.Notes = attributeList.Where (attr => attr.Name == "Notes").FirstOrDefault ().Value;
			todoItem.Done = Convert.ToBoolean (attributeList.Where (attr => attr.Name == "Done").FirstOrDefault ().Value);
			return todoItem;
		}

		public async Task<List<TodoItem>> RefreshDataAsync ()
		{
			var Items = new List<TodoItem> ();

			try {
				var request = new SelectRequest () {
					SelectExpression = string.Format ("SELECT * from {0}", tableName)
				};
				var response = await client.SelectAsync (request);
				foreach (var item in response.Items) {
					Items.Add (FromSimpleDBAttributes (item.Attributes, item.Name));
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
			return Items;
		}

		public async Task SaveTodoItemAsync (TodoItem todoItem)
		{
			try {
				var attributeList = ToSimpleDBReplaceableAttributes (todoItem);
				var request = new PutAttributesRequest () { 
					DomainName = tableName,
					ItemName = todoItem.ID,
					Attributes = attributeList
				};
				await client.PutAttributesAsync (request);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteTodoItemAsync (TodoItem todoItem)
		{
			try {
				var attributeList = ToSimpleDBAttributes (todoItem);
				var request = new DeleteAttributesRequest () {
					DomainName = tableName,
					ItemName = todoItem.ID,
					Attributes = attributeList
				};
				await client.DeleteAttributesAsync (request);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}
	}
}
