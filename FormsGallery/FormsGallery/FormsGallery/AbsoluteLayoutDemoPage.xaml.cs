using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class AbsoluteLayoutDemoPage
	{
		public AbsoluteLayoutDemoPage()
		{
			InitializeComponent();
		}

		bool IsCurrentPage { get; set; }

		protected override void OnAppearing()
        {
            base.OnAppearing();
            IsCurrentPage = true;
            DateTime beginTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1.0  / 30), () =>
            {
                double seconds = (DateTime.Now - beginTime).TotalSeconds;
                double offset = 1 - Math.Abs((seconds % 2) - 1);

                AbsoluteLayout.SetLayoutBounds(Text1,
                    new Rectangle(offset, offset, 
                        AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                AbsoluteLayout.SetLayoutBounds(Text2,
                    new Rectangle(1 - offset, offset,
                        AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                return IsCurrentPage;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            IsCurrentPage = false;
        }
	}
}
