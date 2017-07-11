namespace MyCompany.Forms.PlatformConfiguration.iOS
{
	using System.Linq;
	using Xamarin.Forms;
	using Xamarin.Forms.PlatformConfiguration;
	using FormsElement = Xamarin.Forms.Label;

	public static class Shadow
	{
		const string EffectName = "MyCompany.LabelShadowEffect";

		public static readonly BindableProperty IsShadowedProperty = BindableProperty.CreateAttached("IsShadowed", typeof(bool), typeof(Shadow), false, propertyChanged: OnIsShadowedPropertyChanged);

		public static bool GetIsShadowed(BindableObject element)
		{
			return (bool)element.GetValue(IsShadowedProperty);
		}

		public static void SetIsShadowed(BindableObject element, bool value)
		{
			element.SetValue(IsShadowedProperty, value);
		}

		public static bool IsShadowed(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetIsShadowed(config.Element);
		}

		public static IPlatformElementConfiguration<iOS, FormsElement> SetIsShadowed(this IPlatformElementConfiguration<iOS, FormsElement> config, bool value)
		{
			SetIsShadowed(config.Element, value);
			return config;
		}

		static void OnIsShadowedPropertyChanged(BindableObject element, object oldValue, object newValue)
		{
			if ((bool)newValue)
			{
				AttachEffect(element as FormsElement);
			}
			else
			{
				DetachEffect(element as FormsElement);
			}
		}

		static void AttachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || controller.EffectIsAttached(EffectName))
			{
				return;
			}
			element.Effects.Add(Effect.Resolve(EffectName));
		}

		static void DetachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || !controller.EffectIsAttached(EffectName))
			{
				return;
			}

			var toRemove = element.Effects.FirstOrDefault(e => e.ResolveId == Effect.Resolve(EffectName).ResolveId);
			if (toRemove != null)
			{
				element.Effects.Remove(toRemove);
			}
		}
	}
}

namespace MyCompany.Forms.PlatformConfiguration.Android
{
	using System.Linq;
	using Xamarin.Forms;
	using Xamarin.Forms.PlatformConfiguration;
	using FormsElement = Xamarin.Forms.Label;

	public static class Shadow
	{
		const string EffectName = "MyCompany.LabelShadowEffect";

		public static readonly BindableProperty IsShadowedProperty = BindableProperty.CreateAttached("IsShadowed", typeof(bool), typeof(Shadow), false, propertyChanged: OnIsShadowedPropertyChanged);

		public static bool GetIsShadowed(BindableObject element)
		{
			return (bool)element.GetValue(IsShadowedProperty);
		}

		public static void SetIsShadowed(BindableObject element, bool value)
		{
			element.SetValue(IsShadowedProperty, value);
		}

		public static bool IsShadowed(this IPlatformElementConfiguration<Android, FormsElement> config)
		{
			return GetIsShadowed(config.Element);
		}

		public static IPlatformElementConfiguration<Android, FormsElement> SetIsShadowed(this IPlatformElementConfiguration<Android, FormsElement> config, bool value)
		{
			SetIsShadowed(config.Element, value);
			return config;
		}

		static void OnIsShadowedPropertyChanged(BindableObject element, object oldValue, object newValue)
		{
			if ((bool)newValue)
			{
				AttachEffect(element as FormsElement);
			}
			else
			{
				DetachEffect(element as FormsElement);
			}
		}

		static void AttachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || controller.EffectIsAttached(EffectName))
			{
				return;
			}
			element.Effects.Add(Effect.Resolve(EffectName));
		}

		static void DetachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || !controller.EffectIsAttached(EffectName))
			{
				return;
			}

			var toRemove = element.Effects.FirstOrDefault(e => e.ResolveId == Effect.Resolve(EffectName).ResolveId);
			if (toRemove != null)
			{
				element.Effects.Remove(toRemove);
			}
		}
	}
}

namespace MyCompany.Forms.PlatformConfiguration.UWP
{
	using System.Linq;
	using Xamarin.Forms;
	using Xamarin.Forms.PlatformConfiguration;
	using FormsElement = Xamarin.Forms.Label;

	public static class Shadow
	{
		const string EffectName = "MyCompany.LabelShadowEffect";

		public static readonly BindableProperty IsShadowedProperty = BindableProperty.CreateAttached("IsShadowed", typeof(bool), typeof(Shadow), false, propertyChanged: OnIsShadowedPropertyChanged);

		public static bool GetIsShadowed(BindableObject element)
		{
			return (bool)element.GetValue(IsShadowedProperty);
		}

		public static void SetIsShadowed(BindableObject element, bool value)
		{
			element.SetValue(IsShadowedProperty, value);
		}

		public static bool IsShadowed(this IPlatformElementConfiguration<Windows, FormsElement> config)
		{
			return GetIsShadowed(config.Element);
		}

		public static IPlatformElementConfiguration<Windows, FormsElement> SetIsShadowed(this IPlatformElementConfiguration<Windows, FormsElement> config, bool value)
		{
			SetIsShadowed(config.Element, value);
			return config;
		}

		static void OnIsShadowedPropertyChanged(BindableObject element, object oldValue, object newValue)
		{
			if ((bool)newValue)
			{
				AttachEffect(element as FormsElement);
			}
			else
			{
				DetachEffect(element as FormsElement);
			}
		}

		static void AttachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || controller.EffectIsAttached(EffectName))
			{
				return;
			}
			element.Effects.Add(Effect.Resolve(EffectName));
		}

		static void DetachEffect(FormsElement element)
		{
			IElementController controller = element;
			if (controller == null || !controller.EffectIsAttached(EffectName))
			{
				return;
			}

			var toRemove = element.Effects.FirstOrDefault(e => e.ResolveId == Effect.Resolve(EffectName).ResolveId);
			if (toRemove != null)
			{
				element.Effects.Remove(toRemove);
			}
		}
	}
}
