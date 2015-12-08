using System.Collections.Generic;

namespace Alia
{
	public static class SetUpDatabaseTasks
	{
		public static List<TextTaskTable> SetUpTextTask()
		{
			var textTasks = new List<TextTaskTable> ();

			var taskTask = new TextTaskTable (1, TaskNames.TextTest, 123);

			textTasks.Add (taskTask);
			return textTasks;
		}

		public static List<NavTaskTable> SetUpNavTasks()
		{
			var navTasks = new List<NavTaskTable> ();

			return navTasks;
		}

		public static List<QuizTaskTable> SetUpQuizTasks()
		{
			var quizTasks = new List<QuizTaskTable> ();

			return quizTasks;
		}
	}
}