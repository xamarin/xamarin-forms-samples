//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;
//
//[assembly:XamlCompilation (XamlCompilationOptions.Compile)]
//namespace Styles
//{
//	public class App : Application
//	{
//		public App ()
//		{
//			var buttonStyle = new Style (typeof(Button)) {
//				Setters = {
//					new Setter { 
//						Property = View.HorizontalOptionsProperty,
//						Value = LayoutOptions.Center
//					},
//					new Setter {
//						Property = View.VerticalOptionsProperty,
//						Value = LayoutOptions.CenterAndExpand
//					},
//					new Setter {
//						Property = Button.BorderColorProperty,
//						Value = Color.Lime
//					},
//					new Setter {
//						Property = Button.BorderRadiusProperty,
//						Value = 5
//					},
//					new Setter {
//						Property = Button.BorderWidthProperty,
//						Value = 5
//					},
//					new Setter {
//						Property = VisualElement.WidthRequestProperty,
//						Value = 200
//					},
//					new Setter {
//						Property = Button.TextColorProperty,
//						Value = Color.Teal
//					}
//				}
//			};
//					
//			Resources = new ResourceDictionary ();
//			Resources.Add ("buttonStyle", buttonStyle);
//
//			MainPage = new HomePageCS ();
//		}
//
//		protected override void OnStart ()
//		{
//			// Handle when your app starts
//		}
//
//		protected override void OnSleep ()
//		{
//			// Handle when your app sleeps
//		}
//
//		protected override void OnResume ()
//		{
//			// Handle when your app resumes
//		}
//	}
//}
//
