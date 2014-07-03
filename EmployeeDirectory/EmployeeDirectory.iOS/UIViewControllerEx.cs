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

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace EmployeeDirectory.iOS
{
	/// <summary>
	/// UIViewController Extensions
	/// </summary>
	public static class UIViewControllerEx
	{
		public static void ShowError (this UIViewController vc, string title, Exception ex)
		{
			while (ex.InnerException != null) {
				ex = ex.InnerException;
			}
			ShowError (vc, title, ex.Message);
		}

		public static void ShowError (this UIViewController vc, string title, string message)
		{
			var alert = new UIAlertView (
				title,
				message,
				null,
				NSBundle.MainBundle.LocalizedString ("OK", "Error alert dimissal button title"));
			alert.Show ();
		}
	}
}

