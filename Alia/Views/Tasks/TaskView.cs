using Xamarin.Forms;
using Ninject;
using System.Collections.Generic;
using System;

namespace Alia
{
	public class TaskView : ContentView
	{
		readonly IDatabaseHelper _db;

		public TaskView ()
		{
			var kernel = new StandardKernel();
			_db = kernel.Get<DatabaseHelper>();

			var layout = new StackLayout ();
			layout.Padding = AppSettings.LayoutPadding;

			var items = _db.GetTasks ();

			var gesture = new TapGestureRecognizer();

			gesture.Tapped += Tap;

			foreach (var item in items) {
				var taskViewItem = new TaskViewItem (item);
				taskViewItem.GestureRecognizers.Add (gesture);
				layout.Children.Add (taskViewItem);
			}

			Content = layout;
		}

		static void Tap(object sender, EventArgs e)
		{
			var task = (TaskViewItem)sender;
		}
	}
}