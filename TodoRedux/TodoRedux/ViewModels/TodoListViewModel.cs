using System;
using System.Linq;
using System.Collections.Generic;
using TodoRedux.State;
using Xamarin.Forms;
using TodoRedux.Views;
using PropertyChanged;
using TodoRedux.Helpers;
using System.ComponentModel;

namespace TodoRedux.ViewModels
{
	public class TodoListViewModel : INotifyPropertyChanged
    {
        private readonly INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<TodoItem> Todos { get; set; }

        public TodoItem SelectedItem { get; set; }

        public Command SelectItem => new Command(async () =>
        {
            await _navigation.PushAsync(new TodoItemPage(SelectedItem));
        });

        public Command Add => new Command(async () =>
        {
            await _navigation.PushAsync(new TodoItemPage());
        });

        public TodoListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Todos = new List<TodoItem>();
            App.Store.Subscribe(state => {
                Todos = state.Todos.ToList();
            });

            this.WhenAny(SelectItem.Execute, x => x.SelectedItem);
        }
    }
}
