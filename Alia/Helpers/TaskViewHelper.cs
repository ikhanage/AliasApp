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
				BackgroundColor = Color.FromRgb(102, 102, 153)			
			};


			var backgroundImage = new Image ();
			backgroundImage.Source = AppSettings.AppBackgroundImage;	

			grid.Children.Add (
				new Label {
					BackgroundColor = Color.FromRgb(51, 153, 255)
				},
				0, 1, 0, 2
			);

			grid.Children.Add(
				new Label
				{
					Text = text,
					BackgroundColor = Color.White,
					HorizontalTextAlignment = TextAlignment.Center
				},
				1, 5, 0, 1 //column, col span, row, row span
			);

			grid.Children.Add (
				new Label
				{
					Text = text,
					BackgroundColor = Color.FromRgb(240, 240, 244)	
				},
				1, 3, 1, 2
			);

			grid.Children.Add (
				new Label
				{
					Text = text,
					BackgroundColor = Color.FromRgb(240, 240, 244)	
				},
				3, 5, 1, 2
			);

			return grid;
		}
	}
}

