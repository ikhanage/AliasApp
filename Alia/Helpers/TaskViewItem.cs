using Xamarin.Forms;

namespace Alia
{
	public class TaskViewItem : Grid
	{
		public TaskViewItem(TextTaskTable item)
		{
			Padding = new Thickness (0, 0, 0, 0);
			RowDefinitions.Add(new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) });

			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (10, GridUnitType.Absolute) });
			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });

			RowSpacing = 0;
			ColumnSpacing = 0;

			BackgroundColor = ColourSettings.TaskBackground;	

			Children.Add (
				new Label {
					BackgroundColor = GetTaskColour (item.Completed, item.Locked)
				},
				0, 1, 0, 2
			);

			Children.Add(
				new Label
				{
					Text = item.Name,
					BackgroundColor = ColourSettings.WhiteTextColour,
					TextColor = ColourSettings.BlackTextColour,
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.Center,
					FontSize = AppSettings.LargeFontSize
				},
				1, 2, 0, 1 //column, col span, row, row span
			);
		}

		static Color GetTaskColour (bool completed, bool locked)
		{
			var taskColour = ColourSettings.LockedTask;
			if (completed) {
				taskColour = ColourSettings.CompletedTask;
			}
			else if (!locked) {
				taskColour = ColourSettings.UnlockedTask;
			}
			return taskColour;
		}
	}
}