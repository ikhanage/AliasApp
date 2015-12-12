using System;

namespace Alia
{
	public class QuizTaskView : TextTaskView
	{
		public QuizTaskView (QuizTaskTable quizTask) : base (quizTask)
		{
			Children.Add(new TaskButtons (quizTask.Response1));
			Children.Add(new TaskButtons (quizTask.Response2));
			Children.Add(new TaskButtons (quizTask.Response3));
			Children.Add(new TaskButtons (quizTask.Response4));


		}
	}
}