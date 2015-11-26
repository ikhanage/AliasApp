using System;
using Xamarin.Forms;

namespace Alia
{
	public static class AppSettings
	{
		public static string AppBackgroundImage = "AliaAppBackground.png";
		public static string TestImage = "ChocolateBirthdayCake.png";

		public static Thickness LayoutPadding 
		{
			get
			{
				return Device.OS == TargetPlatform.iOS ? new Thickness (10, 25, 10, 0) : new Thickness (10, 5, 10, 0);
			}
		}
	}
}

