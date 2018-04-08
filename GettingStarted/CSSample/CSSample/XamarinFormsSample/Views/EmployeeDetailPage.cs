using System.Windows.Input;

using Xamarin.Forms;

using XamarinFormsSample.Model;

namespace XamarinFormsSample.Views
{
	/// <summary>
	///   A Xamarin.Forms page for displaying employee details.
	/// </summary>
	class EmployeeDetailPage : ContentPage
	{
		readonly ICommand _deleteCommand;
		readonly Employee _employee;

		public EmployeeDetailPage (Employee employee)
		{
			_employee = employee;

			#region Initialize some properties on the Page
			Padding = new Thickness (20);
			BindingContext = employee;
			#endregion

			#region Initialize the command that will be execute when the user clicks on the delete button.
			_deleteCommand = new Command (() => {
				App.Employees.Remove (_employee);
				Navigation.PopAsync ();
			});
			#endregion

			#region Create the controls for the Page.
			Image employeeImage = new Image {
				HeightRequest = 200,
				Source = ImageSource.FromFile (_employee.ImageUri),
			};

			// Put the two buttons inside a grid
			Grid buttonsLayout = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (2, GridUnitType.Star) },
				},
				Children = {
					{ CreateDeleteButton (), 0, 0 },
					{ CreateSaveButton (), 1, 0 }
				}
			};

			// Create a grid to hold the Labels & Entry controls.
			Grid inputGrid = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
				},
				Children = { {
						new Label {
							Text = "First Name:",
							FontFamily = Fonts.SmallTitle.FontFamily,
							FontSize = Fonts.SmallTitle.FontSize,
							TextColor = Colours.SubTitle
						},
						0,
						0
					}, {
						new Label {
							Text = "Last Name:",
							FontFamily = Fonts.SmallTitle.FontFamily,
							FontSize = Fonts.SmallTitle.FontSize,
							TextColor = Colours.SubTitle
						},
						0,
						1
					}, {
						new Label {
							Text = "Twitter: ",
							HorizontalTextAlignment = TextAlignment.End,
							FontFamily = Fonts.SmallTitle.FontFamily,
							FontSize = Fonts.SmallTitle.FontSize,
							TextColor = Colours.SubTitle
						},
						0,
						2
					},
					{ CreateEntryFor ("FirstName"), 1, 0 },
					{ CreateEntryFor ("LastName"), 1, 1 },
					{ CreateEntryFor ("Twitter"), 1, 2 }
				}
			};
			#endregion

			// Add the controls to a StackLayout 
			Content = new StackLayout {
				Children = {
					employeeImage,
					inputGrid,
					buttonsLayout
				}
			};
		}

		/// <summary>
		///   This is the command to invoke when the user wants to delete the employee.
		/// </summary>
		/// <value>The delete employee command.</value>
		public ICommand DeleteEmployeeCommand { get { return _deleteCommand; } }

		/// <summary>
		///   Create the save button and assing an event handler to the Clicked event.
		/// </summary>
		/// <returns>The save button.</returns>
		View CreateSaveButton ()
		{
			Button saveButton = new Button {
				Text = "Save",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Colours.BackgroundGrey
			};

			saveButton.Clicked += async (sender, e) => await Navigation.PopAsync ();
			return saveButton;
		}

		/// <summary>
		///   Create the delete button and setup the data binding to invoke the DeleteEmployeeCommand.
		/// </summary>
		/// <returns>The delete button.</returns>
		View CreateDeleteButton ()
		{
			// First create the button.
			Button deleteButton = new Button {
				Text = "Delete",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Colours.NegativeBackground
			};

			// Setup data binding.
			deleteButton.SetBinding (Button.CommandProperty, "DeleteEmployeeCommand");
			deleteButton.BindingContext = this;
			return deleteButton;
		}

		/// <summary>
		///   Helper method that will create a Xmaarin.Forms Entry control on the screen.
		/// </summary>
		/// <returns>A Xamarin.Forms Entry control.</returns>
		/// <param name="propertyName">The name of the property to bind to.</param>
		View CreateEntryFor (string propertyName)
		{
			Entry input = new Entry {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			input.SetBinding (Entry.TextProperty, propertyName);
			return input;
		}
	}
}
