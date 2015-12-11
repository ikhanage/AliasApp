using Xamarin.Forms;

namespace Alia
{
	public class TextTaskView : StackLayout
	{
		public TextTaskView (TextTaskTable textTask)
		{
			Padding = AppSettings.LayoutPadding;

			Children.Add (
				new TaskLabel {
					Text = textTask.Name
				}
			);

			Children.Add (
				new TaskLabel {
					Text = textTask.Text
				}
			);
		}
	}
}