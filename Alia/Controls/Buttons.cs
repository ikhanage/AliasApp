using Xamarin.Forms;

namespace Alia
{
	public class TaskButtons : Button
	{
		public TaskButtons (string text)
		{
			Text = text;
			FontSize = AppSettings.LargeFontSize;
			HorizontalOptions = LayoutOptions.CenterAndExpand;
		}
	}
}