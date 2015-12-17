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
			MessagingCenter.Subscribe<LockView> (this, "TaskUpdate", RefreshPage);
			MessagingCenter.Subscribe<TextTaskView> (this, "TaskUpdate", RefreshPage);
			Content = TasksLayout ();
		}

		void RefreshPage(Object sender) 
		{
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

		void TaskTap(object sender, EventArgs e)
		{
			var viewItem = (TaskViewItem)sender;
			Navigation.PushModalAsync (new TaskPage(viewItem.Id));
		}
	}
}