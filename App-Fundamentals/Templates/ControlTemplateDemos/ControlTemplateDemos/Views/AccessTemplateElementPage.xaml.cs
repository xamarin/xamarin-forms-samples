using ControlTemplateDemos.Controls;
using Xamarin.Forms;

namespace ControlTemplateDemos
{
    public partial class AccessTemplateElementPage : HeaderFooterPage
    {
        Label themeLabel;

        public AccessTemplateElementPage()
        {
            InitializeComponent();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            themeLabel = (Label)GetTemplateChild("changeThemeLabel");
            themeLabel.Text = OriginalTemplate ? "Aqua Theme" : "Teal Theme";
        }
    }
}
