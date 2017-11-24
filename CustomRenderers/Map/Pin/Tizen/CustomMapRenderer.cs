using System;
using System.Collections.Generic;
using System.ComponentModel;
using CustomRenderer;
using CustomRenderer.Tizen;
using Tizen.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Tizen;
using Xamarin.Forms.Platform.Tizen;
using NLabel = Xamarin.Forms.Platform.Tizen.Native.Label;
using TPin = Tizen.Maps.Pin;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace CustomRenderer.Tizen
{
    public class CustomMapRenderer : MapRenderer
	{
		const string XamarinId = "Xamarin";

		const double OverlayWidth = 192.3;

		const double OverlayHeight = 60.7;

		static readonly string PinPath = ResourcePath.GetPath("pin.png");

		static readonly string XamarinPath = ResourcePath.GetPath("xamarin.png");

		static readonly string MonkeyPath = ResourcePath.GetPath("monkey.png");

		static readonly string InfoPath = ResourcePath.GetPath("info.png");

		static readonly ElmSharp.Color XamarinLogoColor = new ElmSharp.Color(41, 128, 185);

		List<CustomPin> customPins;

		bool isDrawn = false;

		bool viewReady = false;

		protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
			}

			if (e.NewElement != null)
			{
				customPins = (e.NewElement as CustomMap)?.CustomPins ?? new List<CustomPin>();
				Control.ViewReady += OnViewReady;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName.Equals("VisibleRegion") && viewReady &&!isDrawn)
			{
				Control.RemoveAll();

				var scale = ElmSharp.Elementary.GetScale();
				int windowWidth = (int)Math.Round(OverlayWidth * scale);
				int windowHeight = (int)Math.Round(OverlayHeight * scale);

				foreach (var pin in customPins)
				{
					var coordinates = new Geocoordinates(pin.Position.Latitude, pin.Position.Longitude);

					Control.Add(new TPin(coordinates, PinPath));

					int width = windowWidth;
					int height = windowHeight;

					var window = new ElmSharp.Box(Control);
					window.Show();

					{
						var overlay = new ElmSharp.Box(window)
						{
							BackgroundColor = XamarinLogoColor,
						};
						overlay.SetAlignment(-1.0, -1.0);  // fill
						overlay.SetWeight(1.0, 0.0);  // expand on X axis
						overlay.Show();
						window.PackEnd(overlay);

						if (pin.Id == XamarinId)
						{
							var xamarin = new ElmSharp.Image(overlay);
							xamarin.Load(XamarinPath);
							xamarin.SetAlignment(-1.0, -1.0);  // fill
							var size = xamarin.ObjectSize;
							xamarin.MinimumWidth = size.Width;
							xamarin.MinimumHeight = size.Height;
							xamarin.Show();
							overlay.PackEnd(xamarin);

							height += size.Height;
						}

						{
							var infoBox = new ElmSharp.Box(overlay)
							{
								IsHorizontal = true,
							};
							infoBox.SetAlignment(-1.0, -1.0);  // fill
							infoBox.SetWeight(1.0, 0.0);  // expand on X axis
							infoBox.Show();
							overlay.PackEnd(infoBox);

							{
								var monkey = new ElmSharp.Image(infoBox);
								monkey.Load(MonkeyPath);
								monkey.SetAlignment(-1.0, -1.0);  // fill
								monkey.SetWeight(1.0, 0.0);  // expand on X axis
								monkey.Show();
								infoBox.PackEnd(monkey);
							}

							{
								var textBox = new ElmSharp.Box(infoBox);
								textBox.SetAlignment(-1.0, -1.0);  // fill
								textBox.SetWeight(1.0, 0.0);  // expand on X axis
								textBox.Show();
								infoBox.PackEnd(textBox);

								{
									var title = new NLabel(textBox)
									{
										Text = pin.Label,
										FontAttributes = FontAttributes.Bold,
										TextColor = ElmSharp.Color.White,
									};
									title.SetAlignment(-1.0, -1.0);  // fill
									title.SetWeight(1.0, 0.0);  // expand on X axis
									title.Show();
									textBox.PackEnd(title);
								}

								{
									var subtitle = new NLabel(textBox)
									{
										Text = pin.Address,
										TextColor = ElmSharp.Color.White,
									};
									subtitle.SetAlignment(-1.0, -1.0);  // fill
									subtitle.SetWeight(1.0, 0.0);  // expand on X axis
									subtitle.Show();
									textBox.PackEnd(subtitle);
								}
							}

							{
								var info = new ElmSharp.Image(infoBox);
								info.Load(InfoPath);
								info.SetAlignment(-1.0, -1.0);  // fill
								info.SetWeight(1.0, 0.0);  // expand on X axis
								info.Show();
								infoBox.PackEnd(info);
							}
						}
					}

					{
						var expander = new ElmSharp.Box(window);
						expander.SetAlignment(-1.0, -1.0);  // fill
						expander.SetWeight(1.0, 1.0);  // expand
						expander.Show();
						window.PackEnd(expander);
					}

					window.Resize(width, height);

					Control.Add(new Overlay(coordinates, window));
				}

				isDrawn = true;
			}
		}


		private void OnViewReady(object sender, EventArgs e)
		{
			if (!viewReady)
			{
				isDrawn = false;
				viewReady = true;
			}
		}
	}
}
