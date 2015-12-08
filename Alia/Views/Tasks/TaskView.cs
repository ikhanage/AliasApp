using Xamarin.Forms;
using Ninject;
using System.Collections.Generic;

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

			foreach (var item in items) {
				layout.Children.Add (new TaskViewItem (item));
			}

			Content = layout;
		}
	}
}