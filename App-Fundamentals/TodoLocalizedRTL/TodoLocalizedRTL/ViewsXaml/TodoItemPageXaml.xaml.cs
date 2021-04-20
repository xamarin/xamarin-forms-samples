using System;
using Xamarin.Forms;

namespace TodoLocalized
{
    public partial class TodoItemPageXaml : ContentPage
    {
        public TodoItemPageXaml()
        {
            InitializeComponent();
        }

        async void OnSave(object s, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Database.SaveItem(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDelete(object s, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Database.DeleteItem(todoItem.ID);
            await Navigation.PopAsync();
        }

        async void OnCancel(object s, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnSpeak(object s, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        }
    }
}
