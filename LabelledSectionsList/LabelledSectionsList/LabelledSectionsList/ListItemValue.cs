using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelledSections
{
    // Represents one item in our list.
    public class ListItemValue : IComparable<ListItemValue>
    {
        public string Name { get; private set; }

        public ListItemValue(string name)
        {
            Name = name;
        }

        int IComparable<ListItemValue>.CompareTo(ListItemValue value)
        {
            return Name.CompareTo(value.Name);
        }

        public string Label
        {
            get
            {
                return Name[0].ToString();
            }
        }
    }
}
