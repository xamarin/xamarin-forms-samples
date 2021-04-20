using System;

namespace FlyoutPageNavigation
{
	public class FlyoutPageItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}
}
