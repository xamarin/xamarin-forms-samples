//
//  Copyright 2012, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;

using MonoTouch.UIKit;

using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory.iOS
{
	public class LoginViewController : UIViewController
	{
		LoginViewModel loginViewModel;

		UITextField username;
		UITextField password;
		UIActivityIndicatorView indicator;
		UIButton login;
		UIButton help;

		static readonly UIImage TextFieldBackground = UIImage.FromBundle ("login_textfield.png").CreateResizableImage (new UIEdgeInsets (8, 8, 8, 8));

		public LoginViewController (IDirectoryService service)
		{
			View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromBundle ("login_box.png"));

			loginViewModel = new LoginViewModel (service);

			loginViewModel.IsBusyChanged += (sender, e) => {
				if (IsViewLoaded) {
					if (loginViewModel.IsBusy) {
						indicator.StartAnimating ();
					}
					else {
						indicator.StopAnimating ();
					}
					indicator.Hidden = !loginViewModel.IsBusy;
					login.Enabled = !loginViewModel.IsBusy;
				}
			};

			//
			// Create the UI
			//
			var logo = new UIImageView (UIImage.FromBundle ("logo.png"));
			AddCentered (logo, 33, logo.Image.Size.Width, logo.Image.Size.Height);

			username = new UITextField {
				Placeholder = "Username",
				BorderStyle = UITextBorderStyle.None,
				VerticalAlignment = UIControlContentVerticalAlignment.Center,
				AutocorrectionType = UITextAutocorrectionType.No,
				AutocapitalizationType = UITextAutocapitalizationType.None,
				ClearButtonMode = UITextFieldViewMode.WhileEditing,
				Background = TextFieldBackground,
				LeftView = new UIView (new RectangleF (0, 0, 8, 8)),
				LeftViewMode = UITextFieldViewMode.Always,
				ReturnKeyType = UIReturnKeyType.Next,
				ShouldReturn = delegate {
					password.BecomeFirstResponder ();
					return true;
				},
			};
			AddCentered (username, 80, 200, 44);

			password = new UITextField {
				Placeholder = "Password",
				SecureTextEntry = true,
				BorderStyle = UITextBorderStyle.None,
				VerticalAlignment = UIControlContentVerticalAlignment.Center,
				AutocorrectionType = UITextAutocorrectionType.No,
				AutocapitalizationType = UITextAutocapitalizationType.None,
				ClearButtonMode = UITextFieldViewMode.WhileEditing,
				Background = TextFieldBackground,
				LeftView = new UIView (new RectangleF (0, 0, 8, 8)),
				LeftViewMode = UITextFieldViewMode.Always,
				ReturnKeyType = UIReturnKeyType.Go,
				ShouldReturn = delegate {
					Login ();
					return true;
				},
			};
			AddCentered (password, 132, 200, 44);

			login = UIButton.FromType (UIButtonType.Custom);
			login.SetTitle ("Login", UIControlState.Normal);
			login.SetBackgroundImage (UIImage.FromBundle ("login_btn.png").CreateResizableImage (new UIEdgeInsets (8, 8, 8, 8)), UIControlState.Normal);
			login.TouchUpInside += delegate {
				Login ();
			};
			AddCentered (login, 184, 100, 51);

			help = UIButton.FromType (UIButtonType.Custom);
			help.SetImage (UIImage.FromBundle ("questionmark.png"), UIControlState.Normal);
			help.TouchUpInside += (sender, e) => {
				new UIAlertView("Need Help?", "Enter any username or password to login.", null, "Ok").Show ();
			};
			AddCentered (help, 194, 30, 31);
			
			//Adjust frame of help button
			var frame = help.Frame;
			frame.X = login.Frame.Right + 8;
			help.Frame = frame;

			indicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge) {
				HidesWhenStopped = true,
				Hidden = true,
			};
			frame = indicator.Frame;
			frame.X = login.Frame.X - indicator.Frame.Width - 8;
			frame.Y = login.Frame.Y + 6;
			indicator.Frame = frame;
			View.AddSubview (indicator);
		}

		void AddCentered (UIView view, float y, float width, float height)
		{
			var f = new RectangleF ((320 - width) / 2, y, width, height);
			view.Frame = f;
			view.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;
			View.AddSubview (view);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
		}

		void Login ()
		{
            if (string.IsNullOrEmpty(username.Text))
            {
                var view = new UIAlertView("Oops", "Please enter a username.", null, "Ok");
                view.Dismissed += (sender, e) => username.BecomeFirstResponder();
                view.Show();
                return;
            }
            if (string.IsNullOrEmpty(password.Text))
            {
                var view = new UIAlertView("Oops", "Please enter a password.", null, "Ok");
                view.Dismissed += (sender, e) => password.BecomeFirstResponder();
                view.Show();
                return;
            }

			username.ResignFirstResponder ();
			password.ResignFirstResponder ();

			loginViewModel.Username = username.Text;
			loginViewModel.Password = password.Text;

			loginViewModel.LoginAsync (CancellationToken.None).ContinueWith (t => {

				if (t.IsCompleted && !t.IsFaulted) {
					DismissViewController (true, null);
				}

			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}
	}
}

