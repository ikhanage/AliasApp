using System;

using Xamarin.Forms;
using Ninject;

namespace Alia
{
	public class TaskPage : ContentPage
	{
		public TaskPage (int id)
		{
			var kernel = new StandardKernel();
			var _db = kernel.Get<DatabaseHelper> ();
			var task = _db.GetTaskById (id);

			Padding = AppSettings.LargeFontSize;
			BackgroundImage = AppSettings.AppBackgroundImage;

			if (task.Locked) {
				Content = new LockView (task.Id, task.UnlockCode);
			} else {
				switch (task.PageType) {
				case PageTypes.TextPage:
					Content = new TextTaskView (task);					
					break;

				case PageTypes.NavPage:
					Content = new NavTaskView ((NavTaskTable)task);
					break;

				case PageTypes.QuizPage:
					Content = new QuizTaskView ((QuizTaskTable)task);
					break;
				}
			}
		}
	}
}