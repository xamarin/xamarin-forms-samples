using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using PCLStorage;

namespace TablesLists.Data
{
	public class ItemsRepository
	{
		public List<ItemsGroup> Groups { get; set; }

		public static async Task<ItemsRepository> OpenIsolatedStorage (string storageName)
		{
			IFolder store = FileSystem.Current.LocalStorage;
			IFile file = await store.GetFileAsync (storageName);

			try {
				var task = file.OpenAsync (FileAccess.Read);
				task.Wait ();
				var result = task.Result;
				using (var inputStream = new StreamReader (result)) {

					return new ItemsRepository {
						Groups = ReadGroupsXml (inputStream)
					};
				}
			} catch (Exception) {
				return new ItemsRepository {
					Groups = new List<ItemsGroup> ()
				};
			}
		}

		private static List<ItemsGroup> ReadGroupsXml (StreamReader inputStream)
		{
			var itemsGroup = new List<ItemsGroup> ();
			var xdoc = XDocument.Load (inputStream);
			var units = xdoc.Descendants ("Group");

			foreach (var group in units) {
				var title = group.Attribute ("Title").Value;

				var items = new List<Item> ();
				foreach (var item in group.Elements("Item")) {
					items.Add (new Item {
						Title = GetAttributeValue ("Title", item),
						Subtitle = GetAttributeValue ("Subtitle", item),
						ImageSource = GetAttributeValue ("ImageSource", item),
						NavigationPage = GetAttributeValue ("NavigationPage", item),
						ItemsSourceFile = GetAttributeValue ("ItemsSourceFile", item)
					});
				}

				itemsGroup.Add (new ItemsGroup (title, items));
			}

			return itemsGroup;
		}

		private static string GetAttributeValue (string attributeName, XElement xmlNode)
		{
			var attribute = xmlNode.Attribute (attributeName);
			return attribute == null ? string.Empty : attribute.Value; 
		}
	}
}

