using Xamarin.Forms;

namespace Alia
{
	public class TaskListTemplate : ViewCell
	{
		Label Status;
		Label Title;
		Grid grid;
		public TaskListTemplate()
		{
			grid = new Grid();
			Status = new Label ();

			Title = new Label {
				BackgroundColor = ColourSettings.WhiteTextColour,
				TextColor = ColourSettings.BlackTextColour,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = AppSettings.LargeFontSize
			};

			Title.SetBinding (Label.TextProperty, "Title");
			Status.SetBinding (VisualElement.BackgroundColorProperty, "StatusColour");

			grid.Padding = new Thickness (0, 0, 0, 0);
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) });

			grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (10, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) });

			grid.RowSpacing = 0;
			grid.ColumnSpacing = 0;

			grid.BackgroundColor = ColourSettings.TaskBackground;	

			grid.Children.Add (
				Status,
				0, 1, 0, 2
			);

			grid.Children.Add (
				Title,
				1, 2, 0, 1 //column, col span, row, row span
			);

			View = grid;
		}
	}
}