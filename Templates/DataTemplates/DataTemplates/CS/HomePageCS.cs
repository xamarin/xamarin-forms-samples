using Xamarin.Forms;

namespace DataTemplates
{
    public class HomePageCS : TabbedPage
    {
        public HomePageCS()
        {
            Children.Add(new WithoutDataTemplatePageCS());
            Children.Add(new WithDataTemplatePageCS());
            Children.Add(new WithDataTemplatePageFromTypeCS());
        }
    }
}
