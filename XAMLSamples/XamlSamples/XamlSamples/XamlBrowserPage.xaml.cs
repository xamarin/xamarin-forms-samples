using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlSamples
{
    public partial class XamlBrowserPage
    {
        public XamlBrowserPage(string xaml)
        {
            InitializeComponent();
            label.Text = xaml;
        }
    }
}
