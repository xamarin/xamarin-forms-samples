using System;
using Xamarin.Forms;
using CSharpForMarkupDemos.ViewModels;

namespace CSharpForMarkupDemos.Views
{
    public partial class NestedListPage : BaseContentPage<NestedListViewModel>
    {
        public NestedListPage() => Build();

        void List_ItemSelected(object sender, SelectedItemChangedEventArgs e) => ((ListView)sender).SelectedItem = null; // Prevent item selection

        partial class ListItemSelector : DataTemplateSelector
        {
            readonly DataTemplate template, emptyTemplate;

            protected override DataTemplate OnSelectTemplate(object item, BindableObject container) => item is ListItem listItem && !listItem.IsDummy ? template : emptyTemplate;

            void DecreaseCount(object sender, EventArgs args)
            {
                var button = (Button)sender;
                var listItem = (ListItem)button.BindingContext;

                listItem.DecreaseCountCommand.Execute(null);
                ForceUpdateContainingCellSize(button);
            }

            void IncreaseCount(object sender, EventArgs args)
            {
                var button = (Button)sender;
                var listItem = (ListItem)button.BindingContext;

                listItem.IncreaseCountCommand.Execute(null);
                ForceUpdateContainingCellSize(button);
            }

            void ForceUpdateContainingCellSize(Element element)
            {
                for (var parent = element?.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent is ViewCell viewCell) { viewCell.ForceUpdateSize(); break; }
                }
            }
        }

    }
}
