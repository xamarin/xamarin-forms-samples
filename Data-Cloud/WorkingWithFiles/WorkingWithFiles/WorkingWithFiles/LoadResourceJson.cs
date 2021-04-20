using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace WorkingWithFiles
{
	public class LoadResourceJson : ContentPage
	{
		public LoadResourceJson()
		{
			#region How to load an Json file embedded resource
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
			Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.LibJsonResource.json");
			
            Earthquake[] earthquakes;
			using (var reader = new StreamReader(stream))
			{
				var json = reader.ReadToEnd();
				var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
				earthquakes = rootobject.earthquakes;
			}
			#endregion

			var listView = new ListView();
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Data");
                return textCell;
            });
            listView.ItemsSource = earthquakes;

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = 
                {
					new Label { Text = "Embedded Resource JSON File",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					}, listView
				}
			};

			// NOTE: use for debugging, not in released app code!
			//foreach (var res in assembly.GetManifestResourceNames()) 
			//	System.Diagnostics.Debug.WriteLine("found resource: " + res);
		}
	}
}

