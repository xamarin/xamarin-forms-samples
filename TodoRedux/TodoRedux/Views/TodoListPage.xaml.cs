using TodoRedux.ViewModels;
using Xamarin.Forms;

namespace TodoRedux.Views
{
    public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
            BindingContext = new TodoListViewModel(Navigation);
		}
	}
}
