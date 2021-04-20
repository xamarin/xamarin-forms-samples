using System.Windows.Input;

namespace PlatformSpecifics
{
	public class NavigationItem
	{
		public string Text { get; private set; }
		public string Icon { get; private set; }
		public ICommand Command { get; private set; }

		public NavigationItem(string text, string icon, ICommand command)
		{
			Text = text;
			Icon = icon;
			Command = command;
		}
	}
}
