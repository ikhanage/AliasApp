using Xamarin.Forms;

namespace Alia
{
	public class TaskViewItem : Grid
	{
		public TaskViewItem(string title, int unlockCode)
		{
			Padding = new Thickness (0, 0, 0, 0);
			RowDefinitions.Add(new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) });
			RowDefinitions.Add(new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) });

			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (10, GridUnitType.Absolute) });
			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });
			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });
			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });
			ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });


			RowSpacing = 1;
			ColumnSpacing = 0;
			BackgroundColor = ColourSettings.TaskBackground;	


			var backgroundImage = new Image ();
			backgroundImage.Source = AppSettings.AppBackgroundImage;	

			Children.Add (
				new Label {
					BackgroundColor = ColourSettings.CompletedTask
				},
				0, 1, 0, 2
			);

			Children.Add(
				new Label
				{
					Text = title,
					BackgroundColor = ColourSettings.WhiteTextColour,
					TextColor = ColourSettings.BlackTextColour,
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.Center,
					FontSize = AppSettings.LargeFontSize
				},
				1, 5, 0, 1 //column, col span, row, row span
			);

			Children.Add (
				new TaskNumberPicker (),
				1, 5, 1, 2
			);
		}
	}
}