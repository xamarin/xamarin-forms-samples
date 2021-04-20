using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Accessibility
{
    public class TabIndexPageCS : ContentPage
    {
        IList<View> _views;
        bool _tabIndexOrderAscending = true;

        public TabIndexPageCS()
        {
            var grid = new Grid { Margin = new Thickness(20) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }); 
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var tabIndexButton = new Button { Text = "Descending TabIndex" };
            tabIndexButton.Clicked += (sender, e) => 
            {
                int index = -100000;

                if (_tabIndexOrderAscending)
                    _views.ForEach(v => v.TabIndex = index--);
                else
                    _views.ForEach(v => v.TabIndex = index++);

                _tabIndexOrderAscending = !_tabIndexOrderAscending;
                tabIndexButton.Text = tabIndexButton.Text == "Descending TabIndex" ? "Ascending TabIndex" : "Descending TabIndex";
            };

            var zeroTabIndexButton = new Button { Text = "All TabIndex = 0" };
            zeroTabIndexButton.Clicked += (sender, e) => 
            {
                _views.ForEach(v => v.TabIndex = 0);
            };

            var toggleIsTabStopButton = new Button { Text = "Toggle IsTabStop" };
            toggleIsTabStopButton.Clicked += (sender, e) => 
            {
                _views.ForEach(v => v.IsTabStop = !v.IsTabStop);
            };

            var alternatingIsTabStopButton = new Button { Text = "Alternating IsTabStop" };
            alternatingIsTabStopButton.Clicked += (sender, e) => 
            {
                for (int i = 0; i < _views.Count; i++)
                {
                    _views[i].IsTabStop = i % 2 == 0;
                }
            };

            grid.Children.Add(tabIndexButton, 0, 0);
            grid.Children.Add(zeroTabIndexButton, 1, 0);
            grid.Children.Add(toggleIsTabStopButton, 0, 1);
            grid.Children.Add(alternatingIsTabStopButton, 1, 1);

            var picker = new Picker { Title = "Select a monkey", TabIndex = 50 };
            picker.ItemsSource = new List<string>()
            {
                "Baboon", "Capuchin Monkey", "Blue Monkey", "Squirrel Monkey", "Golden Lion Tamarin", "Howler Monkey", "Japanese Macaque"
            };

            var stackLayout = new StackLayout()
            {
                Children = 
                {
                    new Button { Text="Save", TabIndex=10},
                    new DatePicker { TabIndex=20},
                    new Editor { Placeholder="Enter data", TabIndex=30},
                    new Entry { Placeholder="Enter name", TabIndex=40},
                    picker,
                    new ProgressBar { Progress = 0.5, TabIndex=60},
                    new SearchBar { Placeholder = "Enter search term", TabIndex=70},
                    new Slider { TabIndex = 80},
                    new Stepper { TabIndex = 90},
                    new Switch { TabIndex = 100},
                    new TimePicker { TabIndex = 110}
                }
            };

            _views = stackLayout.Children;

            grid.Children.Add(stackLayout, 0, 2);
            Grid.SetColumnSpan(stackLayout, 2);


            Content = grid;
        }
    }
}
