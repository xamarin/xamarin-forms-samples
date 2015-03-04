using System;

namespace FormsGallery
{
	public partial class ButtonDemoPage
	{
		public ButtonDemoPage()
		{
			InitializeComponent();
		}

		int ClickTotal { get; set; }

		void Button_OnClicked( object sender, EventArgs e )
		{
			ClickTotal += 1;
            Label.Text = String.Format("{0} button click{1}",
                                       ClickTotal, ClickTotal == 1 ? string.Empty : "s");
		}
	}
}
