using Xamarin.Forms;
using Ninject;

namespace Alia
{
	public class LockView : StackLayout
	{
		readonly int TaskId;
		readonly int UnlockCode;
		readonly IDatabaseHelper _db;
		TaskNumberPicker AnswerEntry;

		public LockView (int id, int unlockCode)
		{
			var kernel = new StandardKernel ();
			_db = kernel.Get<DatabaseHelper> ();

			AnswerEntry = new TaskNumberPicker ();
			AnswerEntry.TextChanged += AnswerEntered;

			TaskId = id;
			UnlockCode = unlockCode;

			Children.Add (AnswerEntry);
		}

		void AnswerEntered (object sender, TextChangedEventArgs e)
		{
			if(UnlockCode.ToString() == e.NewTextValue || e.NewTextValue == "28284646135")
			{
				_db.UpdateLockStatus (TaskId);
				AnswerEntry.Unfocus ();
				MessagingCenter.Send (this, "TaskUpdate");
				Navigation.PopModalAsync ();
			}
		}
	}
}