using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class ListViewDemoPage
	{
		public ListViewDemoPage()
		{
			InitializeComponent();
		}
	}

    class Person
    {
        public string Name { set; get; }

        public DateTime Birthday { set; get; }

        public Color FavoriteColor { set; get; }
    };

}
