using Xamarin.Forms;

namespace Alia
{
	public class NavTaskView : TextTaskView
	{
		readonly int CodeToUnlock;
		readonly int UnlockCode;

		public NavTaskView (NavTaskTable navTask) : base (navTask)
		{
			var answerEntry = new TaskNumberPicker ();
			answerEntry.TextChanged += AnswerEntryChanged;

			CodeToUnlock = navTask.CodeToComplete;
			UnlockCode = navTask.UnlockCode;
		}

		void AnswerEntryChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue == CodeToUnlock.ToString())
				AnswerLabel.Text = UnlockCode.ToString ();

			if (e.NewTextValue.Length > 3) 
				((Entry)sender).Text = string.Empty;
		}
	}
}