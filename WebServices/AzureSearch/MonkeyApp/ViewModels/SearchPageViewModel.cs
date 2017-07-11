using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace MonkeyApp
{
	public class SearchPageViewModel
	{
		public ObservableCollection<Monkey> Monkeys { get; private set; }

		public ICommand SearchCommand { get; private set; }

		SearchIndexClient indexClient;

		public SearchPageViewModel()
		{
			SearchCommand = new Command<string>(async (text) => await AzureSearch(text));
			Monkeys = new ObservableCollection<Monkey>();
			indexClient = new SearchIndexClient(Constants.SearchServiceName, Constants.Index, new SearchCredentials(Constants.QueryApiKey));
		}

		async Task AzureSearch(string text)
		{
			Monkeys.Clear();

			var searchResults = await indexClient.Documents.SearchAsync<Monkey>(text);
			foreach (SearchResult<Monkey> result in searchResults.Results)
			{
				Monkeys.Add(new Monkey
				{
					Name = result.Document.Name,
					Location = result.Document.Location,
					Details = result.Document.Details,
					ImageUrl = result.Document.ImageUrl
				});
			}
		}
	}
}
