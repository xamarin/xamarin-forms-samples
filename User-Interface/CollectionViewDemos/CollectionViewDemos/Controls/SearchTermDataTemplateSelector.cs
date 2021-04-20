using Xamarin.Forms;

namespace CollectionViewDemos.Controls
{
    public class SearchTermDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate OtherTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            string query = (string)item;
            return query.ToLower().Equals("xamarin") ? OtherTemplate : DefaultTemplate;
        }
    }
}
