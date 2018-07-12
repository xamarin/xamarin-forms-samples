using System;
using System.Reflection;
using System.IO;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	public class LoadResourceText : ContentPage 
	{
		public LoadResourceText ()
		{
			var editor = new Label { Text = "loading...", HeightRequest = 300};

			#region How to load a text file embedded resource
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
			Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.LibTextResource.txt");

			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) {
				text = reader.ReadToEnd ();
			}
			#endregion

			editor.Text = text;

			Content = new StackLayout {
                Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Embedded Resource Text File", 
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					}, editor
				}
			};

			// NOTE: use for debugging, not in released app code!
			//foreach (var res in assembly.GetManifestResourceNames()) 
			//	System.Diagnostics.Debug.WriteLine("found resource: " + res);
		}
	}
}

