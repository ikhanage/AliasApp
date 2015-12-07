using System;

using Xamarin.Forms;

namespace Alia
{
	public class TaskPage : ContentPage
	{
		public TaskPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}