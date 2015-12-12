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

		public static Thickness TaskPadding 
		{
			get
			{
				return Device.OS == TargetPlatform.iOS ? new Thickness (20, 25, 20, 0) : new Thickness (20, 5, 20, 0);
			}
		}

		public static double LargeFontSize
		{
			get
			{
				return Device.GetNamedSize(NamedSize.Small, typeof(Label));
			}
		}
	}
}