using System;
using System.Text;
using Xamarin.Forms;

namespace FileUploader
{
	public class TextFileBrowserPageCS : ContentPage
	{
		string fileName;
		ListView listView;
		Editor editor;
		Button deleteButton;

		public TextFileBrowserPageCS()
		{
			var getFilesButton = new Button { Text = "Get Text File List" };
			getFilesButton.Clicked += OnGetFileListButtonClicked;

			editor = new Editor { HeightRequest = 100, IsEnabled = false };

			listView = new ListView();
			listView.ItemSelected += async (sender, e) =>
			{
				fileName = e.SelectedItem.ToString();
				var byteData = await AzureStorage.GetFileAsync(ContainerType.Text, fileName);
				var text = Encoding.UTF8.GetString(byteData);
				editor.Text = text;
				deleteButton.IsEnabled = true;
			};

			deleteButton = new Button
			{
				Text = "Delete",
				IsEnabled = false
			};
			deleteButton.Clicked += async (sender, e) =>
			{
				if (!string.IsNullOrWhiteSpace(fileName))
				{
					bool isDeleted = await AzureStorage.DeleteFileAsync(ContainerType.Text, fileName);
					if (isDeleted)
					{
						OnGetFileListButtonClicked(sender, e);
					}
				}
			};

			Title = "Text File Browser";
			Icon = "csharp.png";

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Text File Browser", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					getFilesButton,
					listView,
					new Label { Text = "Text file contents:" },
					editor,
					deleteButton
				}
			};
		}

		async void OnGetFileListButtonClicked(object sender, EventArgs e)
		{
			var fileList = await AzureStorage.GetFilesListAsync(ContainerType.Text);
			listView.ItemsSource = fileList;
			editor.Text = string.Empty;
			deleteButton.IsEnabled = false;
		}
	}
}

