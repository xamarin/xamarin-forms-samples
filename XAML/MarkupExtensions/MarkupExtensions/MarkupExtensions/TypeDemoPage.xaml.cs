using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarkupExtensions
{
    public partial class TypeDemoPage : ContentPage
    {
        public TypeDemoPage()
        {
            InitializeComponent();

            CreateCommand = new Command<Type>((Type viewType) =>
            {
                View view = (View)Activator.CreateInstance(viewType);
                view.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackLayout.Children.Add(view);
            });

            BindingContext = this;
        }

        public ICommand CreateCommand { private set; get; }
    }
}