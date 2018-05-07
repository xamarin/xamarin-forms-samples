using System;
using System.Linq;
using Xamarin.Forms;
using TodoLocalized.Resx;

namespace TodoLocalized
{
    public partial class TodoListPageXaml : ContentPage
    {
        public TodoListPageXaml()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetItems();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPageXaml
            {
                BindingContext = new TodoItem()
            });
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            var notDoneItems = App.Database.GetItemsNotDone();
            string toSpeak = string.Empty;
            foreach (var item in notDoneItems)
            {
                toSpeak += item.Name + " ";
            }
            if (string.IsNullOrWhiteSpace(toSpeak))
            {
                toSpeak = "There are no tasks to do";
            }
            if (notDoneItems.Any())
            {
                var s = L10n.Localize("SpeakTaskCount", AppResources.Culture);
                toSpeak = string.Format(s, notDoneItems.Count()) + toSpeak;
            }
            DependencyService.Get<ITextToSpeech>().Speak(toSpeak);
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPageXaml
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}
