using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace MonkeyApp
{
	public class SuggestionsPageViewModel
	{
		public ObservableCollection<Monkey> Suggestions { get; private set; }

		public ICommand SuggestionsCommand { get; private set; }

		SearchIndexClient indexClient;

		public SuggestionsPageViewModel()
		{
			SuggestionsCommand = new Command<string>(async (text) => await AzureSuggestions(text));
			Suggestions = new ObservableCollection<Monkey>();
			indexClient = new SearchIndexClient(Constants.SearchServiceName, Constants.Index, new SearchCredentials(Constants.QueryApiKey));
		}

		async Task AzureSuggestions(string text)
		{
			Suggestions.Clear();

			var parameters = new SuggestParameters()
			{
				UseFuzzyMatching = true,
				HighlightPreTag = "[",
				HighlightPostTag = "]",
				MinimumCoverage = 100,
				Top = 10
			};

			var suggestionResults = await indexClient.Documents.SuggestAsync<Monkey>(text, "nameSuggester", parameters);
			foreach (var result in suggestionResults.Results)
			{
				Suggestions.Add(new Monkey
				{
					Name = result.Text,
					Location = result.Document.Location,
					Details = result.Document.Details,
					ImageUrl = result.Document.ImageUrl
				});
			}
		}
	}
}
