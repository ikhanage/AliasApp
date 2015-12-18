using Xamarin.Forms;
using System;
using Ninject;

namespace Alia
{
	public class TextTaskView : StackLayout
	{
		protected readonly AnswerLabel AnswerLabel;
		protected readonly string NextTaskUnlockCode;
		protected readonly AnswerButton AnswerAndReturnButton;
		protected readonly IDatabaseHelper _db;
		private readonly int taskId;

		public TextTaskView (TextTaskTable textTask)
		{
			var kernel = new StandardKernel();
			_db = kernel.Get<DatabaseHelper> ();

			Padding = AppSettings.TaskPadding;

			AnswerLabel = new AnswerLabel ();
			AnswerLabel.Text = textTask.NextTaskUnlockCode.ToString ();
			NextTaskUnlockCode = textTask.NextTaskUnlockCode.ToString ();

			AnswerAndReturnButton = new AnswerButton{	Text = "Unlock Next Task" };
			AnswerAndReturnButton.Clicked += AnswerAndReturnButton_Clicked;

			taskId = textTask.Id;

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
			Children.Add (AnswerAndReturnButton);
		}

		void AnswerAndReturnButton_Clicked (object sender, EventArgs e)
		{
			_db.UpdateLockStatus (taskId + 1);
			MessagingCenter.Send (this, "TaskUpdate");
			Navigation.PopModalAsync ();
		}

		void BackTap(object sender, EventArgs e)
		{
			Navigation.PopModalAsync ();
		}
	}
}