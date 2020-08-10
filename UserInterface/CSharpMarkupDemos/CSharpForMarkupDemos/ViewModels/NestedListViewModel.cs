using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.ViewModels
{
    public class NestedListViewModel : BaseViewModel
    {
        readonly App app;
        ICommand addGroupCommand;
        ICommand removeGroupCommand;
        ICommand removeItemCommand;
        ICommand returnToPreviousViewCommand;

        public string Title { get; set; } = "Xamarin.Forms C# Markup";
        public string Subtitle { get; set; } = "Nested List";

        public ObservableCollection<ListGroup> Groups { get; set; } = new ObservableCollection<ListGroup>();
        public ICommand AddGroupCommand => addGroupCommand ?? (addGroupCommand = new RelayCommand(AddGroup));
        public ICommand RemoveGroupCommand => removeGroupCommand ?? (removeGroupCommand = new RelayCommand<ListGroup>(RemoveGroup));
        public ICommand RemoveItemCommand => removeItemCommand ?? (removeItemCommand = new RelayCommand<ListItem>(RemoveItem));
        public ICommand ReturnToPreviousViewCommand => returnToPreviousViewCommand ?? (returnToPreviousViewCommand = new RelayCommandAsync(ReturnToPreviousView));

        public NestedListViewModel(App app)
        {
            this.app = app;
            AddGroup();
        }

        void AddGroup() => Groups.Add(new ListGroup { Title = $"Group { Groups.Count + 1 }" });

        void RemoveGroup(ListGroup group) => Groups.Remove(group);

        void RemoveItem(ListItem item)
        {
            if (item.IsDummy) return;

            var group = Groups.FirstOrDefault(g => g.Contains(item));
            if (group == null) return;

            group.Remove(item); group.Update();
        }

        Task ReturnToPreviousView() => app.ReturnToPreviousView();
    }

    public class ListGroup : ObservableCollection<ListItem>
    {
        ICommand addItemCommand;

        public ListGroup() { Items.Add(new ListItem { IsDummy = true }); }

        public ListGroup(IEnumerable<ListItem> items) : base(items) { }

        public string Title { get; set; }

        public bool IsOdd { get; set; }

        public new ObservableCollection<ListItem> Items => this;

        public ICommand AddItemCommand => addItemCommand ?? (addItemCommand = new RelayCommand(AddItem));

        public void Update() => IsOdd = (Items.Count - 1) % 2 == 1;

        void AddItem() { Items.Add(new ListItem { Title = Items.Count.ToString() }); Update(); }
    }

    public class ListItem : BaseViewModel
    {
        ICommand increaseCountCommand, decreaseCountCommand;

        public bool IsDummy { get; set; }

        public string Title { get; set; }

        public int Count { get; set; }

        public string CountText => Pile('\u2b50', Count);

        public ICommand IncreaseCountCommand => increaseCountCommand ?? (increaseCountCommand = new RelayCommand(IncreaseCount, () => Count < 15));

        public ICommand DecreaseCountCommand => decreaseCountCommand ?? (decreaseCountCommand = new RelayCommand(DecreaseCount, () => Count > 0));

        void IncreaseCount() => Count++;

        void DecreaseCount() => Count--;

        string Pile(char c, int count)
        {
            List<string> lines = new List<string>();

            for (int lineLength = 1; count >= lineLength; lineLength++)
            {
                lines.Add(new string(c, lineLength));
                count -= lineLength;
            }

            while (count > 0)
            {
                lines[lines.Count - count] = lines[lines.Count - count] + c;
                count--;
            }

            return string.Join("\n", lines.ToArray());
        }
    }
}
