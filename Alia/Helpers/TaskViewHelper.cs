using Xamarin.Forms;

namespace Alia
{
	public class TaskViewHelper : ITaskViewHelper
	{
		public Grid CreateGridItem(string text)
		{
			var grid = new Grid
			{
				Padding = new Thickness (0, 0, 0, 0),
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (10, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) }
				},

				RowSpacing = 1,
				ColumnSpacing = 0,
				BackgroundColor = ColourSettings.TaskBackground			
			};


			var backgroundImage = new Image ();
			backgroundImage.Source = AppSettings.AppBackgroundImage;	

			grid.Children.Add (
				new Label {
					BackgroundColor = ColourSettings.CompletedTask
				},
				0, 1, 0, 2
			);

			grid.Children.Add(
				new Label
				{
					Text = text,
					BackgroundColor = Color.White,
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.Center
				},
				1, 5, 0, 1 //column, col span, row, row span
			);

			grid.Children.Add (
				NumberPicker.GetTaskNumberPicker(),
				1, 2, 1, 2
			);

			grid.Children.Add (
				NumberPicker.GetTaskNumberPicker(),
				2, 3, 1, 2
			);

			grid.Children.Add (
				NumberPicker.GetTaskNumberPicker(),
				3, 4, 1, 2
			);

			grid.Children.Add (
				NumberPicker.GetTaskNumberPicker(),
				4, 5, 1, 2
			);

			return grid;
		}
	}
}

