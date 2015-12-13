using Xamarin.Forms;

namespace Alia
{
	public class NumberPicker : Entry
	{
		public NumberPicker  ()
		{
			VerticalOptions = LayoutOptions.CenterAndExpand;
			HorizontalOptions = LayoutOptions.Center;
			WidthRequest = 30;
			Keyboard = Keyboard.Numeric;
		}
	}

	public class TaskNumberPicker : NumberPicker
	{
		public TaskNumberPicker()
		{			
			BackgroundColor = ColourSettings.TaskBackground;
			TextColor = ColourSettings.WhiteTextColour;
			WidthRequest = 45;
		}
	}
}