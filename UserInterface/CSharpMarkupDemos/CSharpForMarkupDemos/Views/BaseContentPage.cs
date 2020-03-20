using System;
using CSharpForMarkupDemos.Helpers;
using CSharpForMarkupDemos.ViewModels;
using Xamarin.Forms;

namespace CSharpForMarkupDemos.Views
{
    public class BaseContentPage : ContentPage
    {
        protected static double PageMarginSize = 12;
        protected static double HeaderHeight = 26;
        protected static double CellHorizontalMarginSize = 16;
        protected static double CellVerticalMarginSize = 12;
    }

    public class BaseContentPage<ViewModelType> : BaseContentPage where ViewModelType : BaseViewModel
    {
        protected ViewModelType ViewModel
        {
            get { return (ViewModelType)BindingContext; }
            set { BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                ViewModel?.OnShow();
            }
            catch (Exception ex)
            {
                XLog.Trace(ex);
            }
        }

        protected override void OnDisappearing()
        {
            try
            {
                ViewModel?.OnHide();
                base.OnDisappearing();
            }
            catch (Exception ex)
            {
                XLog.Trace(ex);
            }
        }
    }
}
