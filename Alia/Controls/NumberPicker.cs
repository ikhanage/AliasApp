using Xamarin.Forms;

namespace Alia
{
	public static class NumberPicker
	{
		public static Entry GetNumberPicker ()
		{
			return new Entry
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 30,
				Keyboard = Keyboard.Numeric
			};
		}

		public static Entry GetTaskNumberPicker(){
			var entry = GetNumberPicker();
			entry.BackgroundColor = ColourSettings.TaskBackground;
			entry.TextColor = ColourSettings.WhiteTextColour;
			return entry;
		}
	}
}

