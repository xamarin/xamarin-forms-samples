using Xamarin.Forms;

namespace BindableLayoutDemo.Controls
{
    public class TechItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate XamarinFormsTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return (string)item == "Xamarin.Forms" ? XamarinFormsTemplate : DefaultTemplate;
        }
    }
}
