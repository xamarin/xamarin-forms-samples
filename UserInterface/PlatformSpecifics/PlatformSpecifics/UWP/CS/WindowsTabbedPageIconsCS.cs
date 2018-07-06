using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
	public class WindowsTabbedPageIconsCS : Xamarin.Forms.TabbedPage
	{
        ICommand _returnToPlatformSpecificsPage;

        public WindowsTabbedPageIconsCS (ICommand restore)
		{
            _returnToPlatformSpecificsPage = restore;

            On<Windows>().SetHeaderIconsEnabled(true);
            On<Windows>().SetHeaderIconsSize(new Size(24, 24));

            Children.Add(CreatePage("Todo", "todo.png"));
            Children.Add(CreatePage("Reminders", "reminders.png"));
            Children.Add(CreatePage("Contacts", "contacts.png"));
        }

        ContentPage CreatePage(string title, string icon)
        {
            var toggleButton = new Xamarin.Forms.Button { Text = "Toggle Header Icons" };
            toggleButton.Clicked += (sender, e) => On<Windows>().SetHeaderIconsEnabled(!On<Windows>().GetHeaderIconsEnabled());

            var returnButton = new Xamarin.Forms.Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = title,
                Icon = icon,
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = {
                        new Xamarin.Forms.Label { Text = $"This is the {title} page." },
                        toggleButton,
                        returnButton
                    }
                }
            };
        }
    }
}
