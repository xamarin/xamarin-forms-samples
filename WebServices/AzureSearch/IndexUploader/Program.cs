using System;
using System.Linq;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using MonkeyApp;

namespace IndexUploader
{
	class MainClass
	{
		static SearchServiceClient searchClient;

		public static void Main(string[] args)
		{
			searchClient = new SearchServiceClient(Constants.SearchServiceName, new SearchCredentials(Constants.AdminApiKey));

			CreateSearchIndex();
			UploadDataToSearchIndex();
		}

		static void CreateSearchIndex()
		{
			var index = new Index()
			{
				Name = Constants.Index,
				Fields = new[]
				{
					new Field("id", DataType.String) { IsKey = true, IsRetrievable = true },
					new Field("name", DataType.String) { IsRetrievable = true, IsFilterable = true, IsSortable = true, IsSearchable = true },
					new Field("location", DataType.String) { IsRetrievable = true, IsFilterable = true, IsSortable = true, IsSearchable = true },
					new Field("details", DataType.String) { IsRetrievable = true, IsFilterable = true, IsSearchable = true },
					new Field("imageUrl", DataType.String) { IsRetrievable = true }
				},
				Suggesters = new[]
				{
					new Suggester("nameSuggester", SuggesterSearchMode.AnalyzingInfixMatching, new[] { "name" })
				}
			};

			searchClient.Indexes.Create(index);
		}

		static void UploadDataToSearchIndex()
		{
			var indexClient = searchClient.Indexes.GetClient(Constants.Index);

			var monkeyList = MonkeyData.Monkeys.Select(m => new
			{
				id = Guid.NewGuid().ToString(),
				name = m.Name,
				location = m.Location,
				details = m.Details,
				imageUrl = m.ImageUrl
			});

			var batch = IndexBatch.New(monkeyList.Select(IndexAction.Upload));
			try
			{
				indexClient.Documents.Index(batch);
			}
			catch (IndexBatchException ex)
			{
				// Sometimes when the Search service is under load, indexing will fail for some 
				// documents in the batch. Compensating actions like delaying and retrying should be taken. 
				// Here, the failed document keys are logged.
				Console.WriteLine("Failed to index some documents: {0}", string.Join(", ", ex.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)));
			}
		}
	}
}
