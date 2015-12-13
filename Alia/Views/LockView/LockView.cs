using Xamarin.Forms;
using Ninject;

namespace Alia
{
	public class LockView : StackLayout
	{
		readonly int TaskId;
		readonly int UnlockCode;
		readonly IDatabaseHelper _db;

		public LockView (int id, int unlockCode)
		{
			var kernel = new StandardKernel ();
			_db = kernel.Get<DatabaseHelper> ();

			var answerEntry = new TaskNumberPicker ();
			answerEntry.TextChanged += AnswerEntered;

			TaskId = id;
			UnlockCode = unlockCode;

			Children.Add (answerEntry);
		}

		void AnswerEntered (object sender, TextChangedEventArgs e)
		{
			if(UnlockCode.ToString() == e.NewTextValue)
			{
				_db.UpdateLockStatus (TaskId);
				Children.Add (
					new TaskLabel {
						Text = "Unlocked!"
					}
				);
			}
		}
	}
}