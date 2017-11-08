using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoItemPage : ContentPage
	{
		IBingSpeechService bingSpeechService;
		IBingSpellCheckService bingSpellCheckService;
		ITextTranslationService textTranslationService;
		bool isRecording = false;

		public static readonly BindableProperty TodoItemProperty =
			BindableProperty.Create("TodoItem", typeof(TodoItem), typeof(TodoItemPage), null);

		public TodoItem TodoItem
		{
			get { return (TodoItem)GetValue(TodoItemProperty); }
			set { SetValue(TodoItemProperty, value); }
		}

		public static readonly BindableProperty IsProcessingProperty =
			BindableProperty.Create("IsProcessing", typeof(bool), typeof(TodoItemPage), false);

		public bool IsProcessing
		{
			get { return (bool)GetValue(IsProcessingProperty); }
			set { SetValue(IsProcessingProperty, value); }
		}

		public TodoItemPage()
		{
			InitializeComponent();

			bingSpeechService = new BingSpeechService(new AuthenticationService(Constants.BingSpeechApiKey), Device.RuntimePlatform);
			bingSpellCheckService = new BingSpellCheckService();
			textTranslationService = new TextTranslationService(new AuthenticationService(Constants.TextTranslatorApiKey));
		}

		async void OnRecognizeSpeechButtonClicked(object sender, EventArgs e)
		{
			try
			{
				var audioRecordingService = DependencyService.Get<IAudioRecorderService>();
				if (!isRecording)
				{
					audioRecordingService.StartRecording();

					((Button)sender).Image = "recording.png";
					IsProcessing = true;
				}
				else
				{
					audioRecordingService.StopRecording();
				}

				isRecording = !isRecording;
				if (!isRecording)
				{
					var speechResult = await bingSpeechService.RecognizeSpeechAsync(Constants.AudioFilename);
					Debug.WriteLine("Name: " + speechResult.Name);
					Debug.WriteLine("Confidence: " + speechResult.Confidence);

					if (!string.IsNullOrWhiteSpace(speechResult.Name))
					{
						TodoItem.Name = char.ToUpper(speechResult.Name[0]) + speechResult.Name.Substring(1);
						OnPropertyChanged("TodoItem");
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				if (!isRecording)
				{
					((Button)sender).Image = "record.png";
					IsProcessing = false;
				}
			}
		}

		async void OnSpellCheckButtonClicked(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(TodoItem.Name))
				{
					IsProcessing = true;

					var spellCheckResult = await bingSpellCheckService.SpellCheckTextAsync(TodoItem.Name);
					foreach (var flaggedToken in spellCheckResult.FlaggedTokens)
					{
						TodoItem.Name = TodoItem.Name.Replace(flaggedToken.Token, flaggedToken.Suggestions.FirstOrDefault().Suggestion);
					}
					OnPropertyChanged("TodoItem");

					IsProcessing = false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		async void OnTranslateButtonClicked(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(TodoItem.Name))
				{
					IsProcessing = true;

					TodoItem.Name = await textTranslationService.TranslateTextAsync(TodoItem.Name);
					OnPropertyChanged("TodoItem");

					IsProcessing = false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(TodoItem.Name))
			{
				await App.TodoManager.SaveItemAsync(TodoItem);
			}
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			await App.TodoManager.DeleteItemAsync(TodoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}
