using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class MultiBindingStringFormatCodePage : ContentPage
    {
        public MultiBindingStringFormatCodePage()
        {
            BindingContext = new GroupViewModel();

            Grid grid = new Grid { Margin = new Thickness(20) };

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });            

            Label employee1 = new Label();
            employee1.SetBinding(Label.TextProperty, new MultiBinding
            {
                Bindings = new Collection<BindingBase>
                {
                    new Binding("Employee1.Forename"),
                    new Binding("Employee1.MiddleName"),
                    new Binding("Employee1.Surname")
                },
                StringFormat = "{0} {1} {2}"
            });

            Label employee2 = new Label();
            employee2.SetBinding(Label.TextProperty, new MultiBinding
            {
                Bindings = new Collection<BindingBase>
                {
                    new Binding("Employee2.Forename"),
                    new Binding("Employee2.MiddleName"),
                    new Binding("Employee2.Surname")
                },
                StringFormat = "{0} {1} {2}"
            });

            Label employee3 = new Label();
            employee3.SetBinding(Label.TextProperty, new MultiBinding
            {
                Bindings = new Collection<BindingBase>
                {
                    new Binding("Employee3.Forename"),
                    new Binding("Employee3.MiddleName"),
                    new Binding("Employee3.Surname")
                },
                StringFormat = "{0} {1} {2}"
            });

            Label employee4 = new Label();
            employee4.SetBinding(Label.TextProperty, new MultiBinding
            {
                Bindings = new Collection<BindingBase>
                {
                    new Binding("Employee4.Forename"),
                    new Binding("Employee4.MiddleName"),
                    new Binding("Employee4.Surname")
                },
                StringFormat = "{0} {1} {2}"
            });

            Label employee5 = new Label();
            employee5.SetBinding(Label.TextProperty, new MultiBinding
            {
                Bindings = new Collection<BindingBase>
                {
                    new Binding("Employee5.Forename"),
                    new Binding("Employee5.MiddleName"),
                    new Binding("Employee5.Surname")
                },
                StringFormat = "{0} {1} {2}"
            });

            grid.Children.Add(new Label { Text = "Employee", FontAttributes = FontAttributes.Bold });
            grid.Children.Add(employee1, 0, 1);
            grid.Children.Add(employee2, 0, 2);
            grid.Children.Add(employee3, 0, 3);
            grid.Children.Add(employee4, 0, 4);
            grid.Children.Add(employee5, 0, 5);

            Title = "MultiBinding code demo";
            Content = grid;
        }
    }
}
