using Xamarin.Forms;
using Ninject;
using System.Collections.Generic;
using System;

namespace Alia
{
	public class MainView : ContentView
	{
		readonly IDatabaseHelper _db;

		public MainView ()
		{
			var kernel = new StandardKernel();
			_db = kernel.Get<DatabaseHelper> ();

			Content = TasksLayout ();
		}

		StackLayout TasksLayout()
		{
			var layout = new StackLayout ();
			layout.Padding = AppSettings.LayoutPadding;

			var items = _db.GetTasks ();

			var gesture = new TapGestureRecognizer();

			gesture.Tapped += TaskTap;

			foreach (var item in items) {
				var taskViewItem = new TaskViewItem (item);
				taskViewItem.GestureRecognizers.Add (gesture);
				layout.Children.Add (taskViewItem);
			}

			return layout;
		}

		StackLayout TaskLayout()
		{
			throw new NotImplementedException ();
		}

		 void TaskTap(object sender, EventArgs e)
		{
			var layout = new StackLayout ();
			var viewItem = (TaskViewItem)sender;
			var task = _db.GetTaskById (viewItem.Id);

			switch (task.PageType) {
				case PageTypes.TextPage:
					
					break;

				case PageTypes.NavPage:
					
					break;

				case PageTypes.QuizPage:
					
					break;
			}

			Content = null;
		}

		void BackTap(object sender, EventArgs e)
		{
			Content = TasksLayout ();
		}
	}
}