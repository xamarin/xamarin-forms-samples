using System;
using System.Linq;
using System.ComponentModel;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;

namespace Xamarin.Controls
{
	[Register ("PieChartView")]
	[Preserve (AllMembers = true)]
	public class PieChartView : UIView
	{
		const double FullCircle = Math.PI * 2;

		static readonly CGColor PlaceholderInnerBorder = new CGColor (1f, 1f, 1f);
		static readonly CGColor PlaceholderOuterBorder = new CGColor (0.72f, 0.72f, 0.72f);
		static readonly CGColor PlaceholderColor = new CGColor (0.72f, 0.79f, 0.9f);

		static UIFont LegendFont = UIFont.SystemFontOfSize (13);
		const int LegendSwatchSize = 10;
		const int LegendSpacing = 5;

		static CGColor [] Colors = new CGColor[] {
			new CGColor (0.43f, 0.67f, 0.85f), // blue #6DACDA
			new CGColor (0.66f, 0.82f, 0.16f), // green #A8D229
			new CGColor (0.93f, 0.69f, 0.3f), // orange #ECB04D
			UIColor.LightGray.CGColor
		};

		[Export]
		[Browsable (true)]
		[DisplayName ("Section Names")]
		public string CSVNames {
			get { return string.Join (",", legend); }
			set { legend = string.IsNullOrWhiteSpace (value)? null : value.Split (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
		}

		[Export]
		[Browsable (true)]
		[DisplayName ("Section Values")]
		public string CSVValues {
			get { return string.Join (",", sections); }
			set {
				try {
					sections = string.IsNullOrWhiteSpace (value)? null : value.Split (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select (s => double.Parse (s.Trim ())).ToArray ();
				} catch {
				}
				SetNeedsDisplay ();
			}
		}

		public double this [int index] {
			get { return sections [index]; }
			set {
				sections [index] = value;
				SetNeedsDisplay ();
			}
		}

		string[] legend;
		double[] sections;

		public PieChartView ()
		{
		}

		public PieChartView (IntPtr handle) : base (handle)
		{
		}

		public override void Draw (RectangleF rect)
		{
			var bounds = Bounds;
			var center = new PointF (bounds.Width / 2, bounds.Height / 2);
			var ctx = UIGraphics.GetCurrentContext ();

			if (legend == null || sections == null) {
				ctx.SetFillColor (PlaceholderColor);
				ctx.FillRect (bounds);

				ctx.SetStrokeColor (PlaceholderOuterBorder);
				ctx.StrokeRectWithWidth (bounds, 1f);

				ctx.SetStrokeColor (PlaceholderInnerBorder);
				ctx.StrokeRectWithWidth (bounds.Inset (1f, 1f), 1f);

				return;
			}

			// setup context
			ctx.SelectFont (LegendFont.Name, LegendFont.PointSize, CGTextEncoding.MacRoman);
			ctx.TextMatrix = CGAffineTransform.MakeIdentity ();
			ctx.SetLineWidth (1);
			ctx.SetStrokeColor (UIColor.Black.CGColor);

			// compute legend
			var legendTop = bounds.Height;
			var legendLeft = 0f;
			var sizes = new SizeF [legend.Length];
			for (var i = 0; i < legend.Length; i++) {
				using (var nsstr = new NSString (legend [i]))
					sizes [i] = nsstr.StringSize (LegendFont);

				legendTop -= Math.Max (sizes [i].Height + LegendSpacing, LegendSwatchSize + LegendSpacing);
				legendLeft = Math.Max (legendLeft, sizes [i].Width + LegendSwatchSize + LegendSpacing);
			}
			legendLeft = bounds.Width - legendLeft;

			// draw legend
			var y = legendTop;
			for (var i = 0; i < legend.Length; i++) {

				// color swatch
				var r = new RectangleF (legendLeft, y, LegendSwatchSize, LegendSwatchSize);
				ctx.SetFillColor (Colors [i]);
				ctx.FillRect (r);

				// text
				ctx.SaveState ();
				ctx.TranslateCTM (legendLeft + LegendSwatchSize + LegendSpacing, (y + LegendSwatchSize / 2) + (sizes [i].Height / 4));
				ctx.ScaleCTM (1, -1);
				ctx.SetFillColor (UIColor.Black.CGColor);
				ctx.ShowTextAtPoint (0, 0, legend [i]);
				ctx.RestoreState ();
				y += Math.Max (sizes [i].Height + LegendSpacing, LegendSwatchSize + LegendSpacing);
			}

			// compute sections
			var maxValue = 0d;
			for (var i = 0; i < sections.Length; i++)
				maxValue += sections [i];

			// draw sections
			var start = 0d;
			var radius = Math.Min (Math.Min (center.X, center.Y), Math.Max (Math.Min (legendTop - center.Y, legendLeft - center.X), 1));
			ctx.MoveTo (center.X, center.Y);
			for (var i = 0; i < sections.Length; i++) {
				var angle = FullCircle * (sections [i] / maxValue);

				ctx.SetFillColor (Colors [i]);
				ctx.AddArc (center.X, center.Y, radius, (float)start, (float)(angle + start), false);
				ctx.AddLineToPoint (center.X, center.Y);
				ctx.FillPath ();

				start += angle;
			}
		}
	}
}

