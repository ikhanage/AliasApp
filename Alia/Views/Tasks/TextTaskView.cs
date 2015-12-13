using Xamarin.Forms;
using System;

namespace Alia
{
	public class TextTaskView : StackLayout
	{
		protected readonly AnswerLabel AnswerLabel;
		protected readonly string NextTaskUnlockCode;

		public TextTaskView (TextTaskTable textTask)
		{
			Padding = AppSettings.TaskPadding;

			AnswerLabel = new AnswerLabel ();
			AnswerLabel.Text = textTask.NextTaskUnlockCode.ToString ();
			NextTaskUnlockCode = textTask.NextTaskUnlockCode.ToString ();

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


			Children.Add (AnswerLabel);
		}

		void BackTap(object sender, EventArgs e)
		{
			Navigation.PopModalAsync ();
		}
	}
}