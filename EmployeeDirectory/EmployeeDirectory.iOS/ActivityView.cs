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

using MonoTouch.UIKit;

using System.Drawing;

namespace EmployeeDirectory.iOS
{
	public class ActivityView : UIView
	{
		UIActivityIndicatorView activity;
		UILabel label;

		public string Text {
			get { return label.Text; }
			set { label.Text = value; }
		}

		public bool IsRunning { get; private set; }

		public ActivityView ()
			: base (new RectangleF (0, 0, 88, 88))
		{
			BackgroundColor = UIColor.Black.ColorWithAlpha (0.75f);
			Opaque = false;
			IsRunning = false;
			Layer.CornerRadius = 8;
			AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;

			var b = Bounds;

			label = new UILabel (new RectangleF (8, b.Height - 8 - 20, b.Width - 16, 20)) {
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				Font = UIFont.BoldSystemFontOfSize (UIFont.SmallSystemFontSize),
			};
			AddSubview (label);

			activity = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			var af = activity.Frame;
			af.X = (b.Width - af.Width) / 2;
			af.Y = 12;
			activity.Frame = af;
			AddSubview (activity);
		}

		public void StartInView (UIView superview)
		{
			var b = superview.Bounds;
			var f = Frame;
			f.X = (b.Width - f.Width) / 2;
			f.Y = 33;
			Frame = f;

			activity.StartAnimating ();
			superview.AddSubview (this);

			IsRunning = true;
		}

		public void Stop ()
		{
			activity.StopAnimating ();
			RemoveFromSuperview ();

			IsRunning = false;
		}
	}
}

