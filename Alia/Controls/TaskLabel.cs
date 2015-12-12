using System;
using Xamarin.Forms;

namespace Alia
{
	public class TaskLabel : Label
	{
		public TaskLabel ()
		{
			HorizontalTextAlignment = TextAlignment.Center;
			TextColor = ColourSettings.WhiteTextColour;
		}
	}

	public class TaskHeader : TaskLabel
	{
		public TaskHeader()
		{
			FontSize = 24;
		}
	}

	public class QuizButton : Button
	{
		public QuizButton()
		{

		}
	}
}