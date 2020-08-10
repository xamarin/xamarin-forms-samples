using CSharpForMarkupDemos.Controls;
using CSharpForMarkupDemos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static CSharpForMarkupDemos.Styles;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace CSharpForMarkupDemos.Views
{
    class MainPage : BaseContentPage<MainViewModel>
    {
        public MainPage() => Build();

        enum PageRow
        {
            Header,
            Body
        }

        void Build()
        {
            var app = App.Current;
            var vm = ViewModel = app.MainViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.AliceBlue;

            Content = new Grid
            {
                RowSpacing = 0,
                RowDefinitions = Rows.Define((PageRow.Header, Auto), (PageRow.Body, Star)),

                Children =
                {
                    PageHeader.Create (PageMarginSize, nameof(vm.Title), nameof(vm.SubTitle))
                                      .Row (PageRow.Header),

                    new ScrollView 
                    { 
                        Content = new StackLayout 
                        {
                            Children = 
                            {
                                new NavigateButton ("Registration code demo", nameof(vm.ContinueToRegistrationCommand)),
                                new NavigateButton ("Nested list demo", nameof(vm.ContinueToNestedListCommand)),
                                new NavigateButton ("Animated page demo", nameof(vm.ContinueToAnimatedPageCommand)),
                                new Label { }
                                           .FormattedText (
                                                new Span { Text = "For more information about C# Markup, see " },
                                                new Span { Text = "C# Markup", Style = Link }
                                                          .BindTapGesture (nameof(vm.ContinueToCSharpForMarkupCommand)),
                                                new Span { Text = "." })
                                           .CenterHorizontal ()
                            }
                        } .Margin (10)
                    } .Row (PageRow.Body)
                }
            };
        }

        class NavigateButton : Button
        {
            public NavigateButton(string text, string command)
            {
                Text = text;
                this .Style (FilledButton)
                     .FillExpandHorizontal () .Margin (PageMarginSize)
                     .Bind (command);
            }
        }
    }
}