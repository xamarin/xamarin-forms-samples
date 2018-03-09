using Xamarin.Forms;

namespace XamarinFormsSample.Views
{
    /// <summary>
    ///   This class is a ViewCell that will be displayed for each employee.
    /// </summary>
    class EmployeeCell : ViewCell
    {
        public EmployeeCell()
        {
            StackLayout nameLayout = CreateNameLayout();
            Image image = CreateEmployeeImageLayout;

            StackLayout viewLayout = new StackLayout
                                     {
                                         Orientation = StackOrientation.Horizontal,
                                         Children = { image, nameLayout }
                                     };
            View = viewLayout;
        }

        /// <summary>
        ///   Create a Xamarin.Forms image and bind it to the ImageUri property.
        /// </summary>
        /// <value>The create employee image layout.</value>
        static Image CreateEmployeeImageLayout
        {
            get
            {
                Image image = new Image
                              {
                                  HorizontalOptions = LayoutOptions.Start
                              };
                image.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
                image.WidthRequest = image.HeightRequest = 40;
                return image;
            }
        }

        /// <summary>
        ///   Create a layout to hold the name & twitter handle of the user.
        /// </summary>
        /// <returns>The name layout.</returns>
        static StackLayout CreateNameLayout()
        {
            #region Create a Label for name
            Label nameLabel = new Label
                              {
                                  HorizontalOptions = LayoutOptions.FillAndExpand
                              };
            nameLabel.SetBinding(Label.TextProperty, "DisplayName");
            #endregion

            #region Create a label for the Twitter handler.
            Label twitterLabel = new Label
                                 {
									HorizontalOptions = LayoutOptions.FillAndExpand,
									FontFamily = Fonts.Twitter.FontFamily,
									FontSize = Fonts.Twitter.FontSize,
									FontAttributes = Fonts.Twitter.FontAttributes
                                 };
            twitterLabel.SetBinding(Label.TextProperty, "Twitter");
            #endregion

            StackLayout nameLayout = new StackLayout
                                     {
                                         HorizontalOptions = LayoutOptions.StartAndExpand,
                                         Orientation = StackOrientation.Vertical,
                                         Children = { nameLabel, twitterLabel }
                                     };
            return nameLayout;
        }
    }
}
