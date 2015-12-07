using Xamarin.Forms;
using Ninject;

namespace Alia
{
	public class TaskView : ContentView
	{
		readonly ITaskViewHelper _taskViewHelper;

		public TaskView ()
		{
			var kernel = new StandardKernel();
			_taskViewHelper = kernel.Get<TaskViewHelper>();

			var layout = new StackLayout ();

			layout.Padding = AppSettings.LayoutPadding;
			
			var item1 = _taskViewHelper.CreateGridItem ("Text 1 which is a test like. Don't be bitter about it.");
			var item2 = _taskViewHelper.CreateGridItem ("Text 2");

			layout.Children.Add (item1);
			layout.Children.Add (item2);
			layout.Children.Add (_taskViewHelper.CreateGridItem ("I am a really big dumb dumb"));

			Content = layout;
		}
	}
}