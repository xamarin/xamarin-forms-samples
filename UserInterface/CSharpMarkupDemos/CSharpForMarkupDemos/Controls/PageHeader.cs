using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Markup.LeftToRight;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace CSharpForMarkupDemos.Controls
{
    public static class PageHeader
    {
        static double rowHeight = 25;

        public static double ButtonDistanceFromTopOfPage => rowHeight * 2;

        public static double ButtonHeight => rowHeight;

        enum Row
        {
            StatusBar,
            Title,
            Subtitle
        }

        enum Col
        {
            First,
            BackButton = First,
            Title,
            Last = Title
        }

        public static Grid Create(
            double pageMarginSize,
            string titlePropertyName = null,
            string subTitlePropertyName = null,
            string returnToPreviousViewCommandPropertyName = null,
            string allowBackNavigationPropertyName = null,
            bool centerTitle = false)
        {
            var grid = new Grid
            {
                BackgroundColor = Color.FromHex("#1976D2"),

                ColumnSpacing = 0,
                ColumnDefinitions = Columns.Define(
                    (Col.BackButton, 60),
                    (Col.Title, GridLength.Star)
                ),

                RowDefinitions = Rows.Define(
                    (Row.StatusBar, Device.RuntimePlatform == Device.iOS ? rowHeight : 0),
                    (Row.Title, rowHeight),
                    (Row.Subtitle, rowHeight)
                ),

                Children = 
                {
                    new ContentView
                    { 
                        Content = (returnToPreviousViewCommandPropertyName != null) ?
                            new Button { Text = "<", TextColor = Color.White, BackgroundColor = Color.FromHex("#1976D2") } .Font (24, bold: true)
                                        .Left () .CenterVertical ()
                                        .Bind (Button.CommandProperty, returnToPreviousViewCommandPropertyName)
                            : null
                    }  .Row (Row.Title, Row.Subtitle) .Column (Col.BackButton) .Padding (pageMarginSize, 0)
                       .Invoke (b => { if (allowBackNavigationPropertyName != null) b.Bind (ContentView.IsVisibleProperty, allowBackNavigationPropertyName); }),

                    new Label
                    {
                        LineBreakMode = LineBreakMode.TailTruncation,
                        HorizontalOptions = centerTitle ? LayoutOptions.Center : LayoutOptions.Start,
                        VerticalOptions = subTitlePropertyName != null ? LayoutOptions.End : LayoutOptions.Center,
                        TextColor = Color.White
                    }  .Bold ()
                       .Row (Row.Title, subTitlePropertyName != null ? Row.Title : Row.Subtitle) .Column (centerTitle ? Col.First : Col.Title, centerTitle ? Col.Last : Col.Title)
                       .Invoke (l => { if (titlePropertyName != null) l.Bind(titlePropertyName); })
                }
            };

            if (subTitlePropertyName != null) grid.Children.Add(
                new Label
                {
                    LineBreakMode = LineBreakMode.TailTruncation, TextColor = Color.White,
                    HorizontalOptions = centerTitle ? LayoutOptions.Center : LayoutOptions.Start } .Bold ()
                   .Row (Row.Subtitle) .Column (centerTitle ? Col.First : Col.Title, centerTitle ? Col.Last : Col.Title) .Top ()
                   .Bind (subTitlePropertyName)
            );
            return grid;
        }
    }
}