using Xamarin.Forms;

namespace Alia
{
	public class TasksPage : ContentPage
	{
		public TasksPage ()
		{			
			BackgroundImage = AppSettings.AppBackgroundImage;

			Content = new TaskView();
		}
	}
}


