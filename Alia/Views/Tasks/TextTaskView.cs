using Xamarin.Forms;
using System;

namespace Alia
{
	public class TextTaskView : StackLayout
	{
		public TextTaskView (TextTaskTable textTask)
		{
			Padding = AppSettings.TaskPadding;

			var gesture = new TapGestureRecognizer();

			gesture.Tapped += BackTap;

			var home = new Label {
				Text = "<-- HOME",
				HorizontalOptions = HorizontalOptions
			};

			home.GestureRecognizers.Add (gesture);
			Children.Add (home);

			Children.Add (
				new TaskHeader {
					Text = textTask.Name
				}
			);

			Children.Add (
				new TaskLabel {
					Text = textTask.Text
				}
			);
		}

		void BackTap(object sender, EventArgs e)
		{
			Navigation.PopModalAsync ();
		}
	}
}