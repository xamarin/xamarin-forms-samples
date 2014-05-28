using System;
using MobileCRM.Shared.Pages;
using MobileCRM.iOS.Renderers;
using Xamarin.Forms;


//[assembly: ExportCell(typeof(DetailPage), typeof(CustomerDetailsPageRenderer))]
namespace MobileCRM.iOS.Renderers
{
    class CustomerDetailsPageRenderer : StoryBoardRenderer<CustomerDetailsStoryboard>
	{
        public CustomerDetailsPageRenderer()
            : base("CustomerDetailsStoryboard")
		{
      
		}

		#region implemented abstract members of StoryBoardRenderer

		VisualElement model;
		public override void SetModel (VisualElement model)
		{
			this.model = model;
            ((CustomerDetailsStoryboard)this.ViewController).Model = model;
		}

		public override VisualElement Model {
			get {
				return model;
			}
		}

		#endregion
	}
}

