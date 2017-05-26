using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlSamples
{
    public partial class XamlBrowserPage
    {
		public XamlBrowserPage()
		{
			InitializeComponent();
		}

		private string _xamlString;
		public string XamlString
		{
			get
			{
				return _xamlString;
			}

			set
			{
				_xamlString = value;
				label.Text = _xamlString;
			}
		}
	}
}
