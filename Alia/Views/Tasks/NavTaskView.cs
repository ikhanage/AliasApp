using Xamarin.Forms;

namespace Alia
{
	public class NavTaskView : TextTaskView
	{
		readonly int CodeToUnlock;

		public NavTaskView (NavTaskTable navTask) : base (navTask)
		{
			var answerEntry = new TaskNumberPicker ();
			answerEntry.TextChanged += AnswerEntryChanged;

			CodeToUnlock = navTask.CodeToComplete;
			AnswerLabel.Text = string.Empty;
			AnswerAndReturnButton.IsVisible = false;

			Children.Add (answerEntry);
		}

		void AnswerEntryChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue == CodeToUnlock.ToString ()) {
				AnswerLabel.Text = NextTaskUnlockCode;
				AnswerAndReturnButton.IsVisible = true;
			}

			if (e.NewTextValue.Length > 3) 
				((Entry)sender).Text = string.Empty;
		}
	}
}