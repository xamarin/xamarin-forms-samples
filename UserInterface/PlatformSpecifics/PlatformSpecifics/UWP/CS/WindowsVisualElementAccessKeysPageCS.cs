using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
	public class WindowsVisualElementAccessKeysPageCS : Xamarin.Forms.TabbedPage
	{
        ICommand _returnToPlatformSpecificsPage;

        public WindowsVisualElementAccessKeysPageCS (ICommand restore)
		{
            _returnToPlatformSpecificsPage = restore;
            
            var firstPage = CreatePage(1);
            var stackLayout = firstPage.Content as StackLayout;

            var switchView = new Switch();
            switchView.On<Windows>().SetAccessKey("A");
            var entry = new Entry { Placeholder = "Enter text here" };
            entry.On<Windows>().SetAccessKey("B");
            var button1 = new Button { Text = "Access key C" };
            button1.Clicked += OnButtonClicked;
            button1.On<Windows>().SetAccessKey("C");
            var button2 = new Button { Text = "Access key D, placement left" };
            button2.Clicked += OnButtonClicked;
            button2.On<Windows>()
                .SetAccessKey("D")
                .SetAccessKeyPlacement(AccessKeyPlacement.Left);
            var button3 = new Button { Text = "Access key E, placement right" };
            button3.Clicked += OnButtonClicked;
            button3.On<Windows>()
                .SetAccessKey("E")
                .SetAccessKeyPlacement(AccessKeyPlacement.Right);
            var button4 = new Button { Text = "Access key F, placement top with offsets", Margin = new Thickness(20) };
            button4.Clicked += OnButtonClicked;
            button4.On<Windows>()
                .SetAccessKey("F")
                .SetAccessKeyPlacement(AccessKeyPlacement.Top)
                .SetAccessKeyHorizontalOffset(20)
                .SetAccessKeyVerticalOffset(20);

            stackLayout.Children.Insert(1, switchView);
            stackLayout.Children.Insert(2, entry);
            stackLayout.Children.Insert(3, button1);
            stackLayout.Children.Insert(4, button2);
            stackLayout.Children.Insert(5, button3);
            stackLayout.Children.Insert(6, button4);

            Children.Add(firstPage);
            Children.Add(CreatePage(2));
            Children.Add(CreatePage(3));
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            await DisplayAlert("Button clicked", $"Clicked {button?.Text}", "OK");
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }

        ContentPage CreatePage(int pageNumber)
        {
            var returnButton = new Xamarin.Forms.Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);
            returnButton.On<Windows>()
                .SetAccessKey("G")
                .SetAccessKeyPlacement(AccessKeyPlacement.Bottom);

            var page = new ContentPage
            {
                Title = $"Page {pageNumber}",
                Icon = "csharp.png",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = {
                        new Xamarin.Forms.Label { Text = "Press the alt key once to see the access keys, then press the alt key and an access key.", FontAttributes = FontAttributes.Bold },
                        returnButton
                    }
                }
            };
            page.On<Windows>().SetAccessKey(pageNumber.ToString());
            return page;
        }
    }
}
