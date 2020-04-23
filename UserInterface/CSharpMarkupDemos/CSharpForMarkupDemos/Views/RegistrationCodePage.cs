using CSharpForMarkupDemos.Controls;
using CSharpForMarkupDemos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Markup.LeftToRight;
using static CSharpForMarkupDemos.Styles;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace CSharpForMarkupDemos.Views
{
    public class RegistrationCodePage : BaseContentPage<RegistrationCodeViewModel>
    {
        public RegistrationCodePage() => Build();

        enum PageRow
        {
            Header,
            Body
        }

        enum BodyRow
        {
            Prompt,
            CodeHeader,
            CodeEntry,
            Button
        }

        enum BodyCol
        {
            FieldLabel,
            FieldValidation
        }

        void Build()
        {
            var app = App.Current;
            var vm = ViewModel = app.RegistrationCodeViewModel;
            var fieldNameMargin = new Thickness(20, 10);
            var fieldMargin = new Thickness(PageMarginSize, 0);

            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.AliceBlue;

            Content = new Grid
            {
                RowSpacing = 0,
                RowDefinitions = Rows.Define((PageRow.Header, Auto), (PageRow.Body, Star)),

                Children =
                {
                    PageHeader.Create(
                        PageMarginSize,
                        nameof(vm.RegistrationTitle), nameof(vm.RegistrationSubTitle),
                        returnToPreviousViewCommandPropertyName: nameof(vm.ReturnToPreviousViewCommand),
                        centerTitle:true
                    )  .Row (PageRow.Header),

                    new ScrollView
                    {
                        Content = new Grid
                        {
                            RowSpacing = 0,
                            RowDefinitions = Rows.Define(
                                (BodyRow.Prompt    , 170 ),
                                (BodyRow.CodeHeader, 75  ),
                                (BodyRow.CodeEntry , Auto),
                                (BodyRow.Button    , Auto)
                            ),

                            ColumnDefinitions = Columns.Define(
                                (BodyCol.FieldLabel     , 160 ),
                                (BodyCol.FieldValidation, Star)
                            ),

                            Children =
                            {
                                new Label { LineBreakMode = LineBreakMode.WordWrap } .Font (15) .Bold ()
                                           .Row (BodyRow.Prompt) .ColumnSpan (All<BodyCol>()) .FillExpandHorizontal () .CenterVertical () .Margin (fieldNameMargin) .TextCenterHorizontal ()
                                           .Bind (nameof(vm.RegistrationPrompt)),

                                new Label { Text = "Registration code" } .Bold ()
                                           .Row (BodyRow.CodeHeader) .Column(BodyCol.FieldLabel) .Bottom () .Margin (fieldNameMargin),

                                new Label { } .Italic ()
                                           .Row (BodyRow.CodeHeader) .Column (BodyCol.FieldValidation) .Right () .Bottom () .Margin (fieldNameMargin)
                                           .Bind (nameof(vm.RegistrationCodeValidationMessage)),

                                new Entry { Placeholder = "E.g. 123456", Keyboard = Keyboard.Numeric, BackgroundColor = Color.AliceBlue, TextColor = Color.Black } .Font (15)
                                           .Row (BodyRow.CodeEntry) .ColumnSpan (All<BodyCol>()) .Margin (fieldMargin) .Height (44)
                                           .Bind (nameof(vm.RegistrationCode), BindingMode.TwoWay),

                                new Button { Text = "Verify" } .Style (FilledButton)
                                            .Row (BodyRow.Button) .ColumnSpan (All<BodyCol>()) .FillExpandHorizontal () .Margin (PageMarginSize)
                                            .Bind (Button.IsVisibleProperty, nameof(vm.CanVerifyRegistrationCode))
                                            .Bind (nameof(vm.VerifyRegistrationCodeCommand)),
                            }
                        }
                    } .Row (PageRow.Body)
                }
            };
        }
    }
}