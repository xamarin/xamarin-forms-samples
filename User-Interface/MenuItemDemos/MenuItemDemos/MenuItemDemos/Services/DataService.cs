using System.Collections.Generic;

namespace MenuItemDemos.Services
{
    public static class DataService
    {
        public static List<string> GetListItems(int itemCount = 10)
        {
            List<string> items = new List<string>();
            for (var i = 1; i <= itemCount; i++)
            {
                items.Add($"Item {i}");
            }
            return items;
        }
    }
}
