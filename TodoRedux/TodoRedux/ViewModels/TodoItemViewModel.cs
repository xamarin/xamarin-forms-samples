using System;
using System.ComponentModel;
using PropertyChanged;
using TodoRedux.ActionCreators;
using TodoRedux.Actions;
using TodoRedux.State;
using Xamarin.Forms;

namespace TodoRedux.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TodoItemViewModel
    {
		private readonly INavigation _navigation;
        private readonly TodoItem _model;

		public string Text { get; set; }

        public Command Save 
        {
            get 
            {
                return new Command(async () => {
                    if (_model != null) 
                    {
                        App.Store.Dispatch(TodoActionCreators.UpdateTodo(_model.Id, Text));
					}
                    else 
                    {
                        App.Store.Dispatch(TodoActionCreators.AddTodo(Guid.NewGuid(), Text)); 
                    }
                    await _navigation.PopAsync();
                });
            }
        }

		public Command Delete
		{
			get
			{
				return new Command(async () =>
				{
                    if (_model != null) 
                    {
                        App.Store.Dispatch(TodoActionCreators.RemoveTodo(_model.Id));
                    }
					await _navigation.PopAsync();
				});
			}
		}

		public Command Cancel
		{
			get
			{
				return new Command(async () =>
				{
					await _navigation.PopAsync();
				});
			}
		}

        public TodoItemViewModel(INavigation navigation) : this(navigation, null)
        {
        }

		public TodoItemViewModel(INavigation navigation, TodoItem model)
		{
			_navigation = navigation;
            _model = model;
            if (model != null) 
            {
            	Text = model.Text;
            }
		}
    }
}
