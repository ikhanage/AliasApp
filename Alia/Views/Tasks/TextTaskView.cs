using Xamarin.Forms;

namespace Alia
{
	public class TextTaskView : StackLayout
	{
		public TextTaskView (TextTaskTable textTask)
		{
			Children.Add (
				new Label {
					Text = textTask.Name,
				}
			);

			Children.Add (
				new Label {
					Text = textTask.Text
				}
			);
		}
	}
}