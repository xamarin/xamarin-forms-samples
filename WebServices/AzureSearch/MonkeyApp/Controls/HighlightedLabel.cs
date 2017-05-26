using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MonkeyApp
{
	public class HighlightedLabel : Label
	{
		public static readonly BindableProperty HighlightedTextProperty =
			BindableProperty.Create("HighlightedText", typeof(string), typeof(HighlightedLabel), propertyChanged: OnHighlightedLabelPropertyChanged);

		public string HighlightedText
		{
			get { return (string)GetValue(HighlightedTextProperty); }
			set { SetValue(HighlightedTextProperty, value); }
		}

		static void OnHighlightedLabelPropertyChanged(BindableObject element, object oldValue, object newValue)
		{
			var text = (string)newValue;
			if (!string.IsNullOrWhiteSpace(text))
			{
				string[] splitText = Regex.Split(text, "([\\[\\]])");
				bool highlight = false;

				var formattedString = new FormattedString();
				foreach (var result in splitText)
				{
					if (!string.IsNullOrWhiteSpace(result))
					{
						switch (result)
						{
							case "[":
								highlight = true;
								break;
							case "]":
								break;
							default:
								if (highlight)
								{
									formattedString.Spans.Add(new Span
									{
										Text = result,
										BackgroundColor = Color.Yellow
									});
									highlight = false;
								}
								else
								{
									formattedString.Spans.Add(new Span
									{
										Text = result
									});
								}
								break;
						}
					}
				}

				((HighlightedLabel)element).FormattedText = formattedString;
			}
		}
	}
}
