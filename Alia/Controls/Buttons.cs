using Xamarin.Forms;

namespace Alia
{
	public class TaskButtons : Button
	{
		public int ButtonId { private set; get; }
		public string ResponseText { private set; get; }

		public TaskButtons (string text, string responseText, int id)
		{
			Text = text;
			FontSize = AppSettings.LargeFontSize;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			ButtonId = id;
			ResponseText = responseText;
		}
	}
}