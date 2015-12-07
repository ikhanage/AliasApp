using System.Collections.Generic;

namespace Alia
{
	public static class SetUpDatabaseTasks
	{
		public static List<TaskTable> SetUpTextTask()
		{
			var textTasks = new List<TaskTable> ();

			var taskTask = new TaskTable { Id = 1, Name = TaskNames.TextTest.ToString(), Text = GetText.GetTextPageText (TaskNames.TextTest), UnlockCode = 123, PageType = PageTypes.TextPage, Completed = false };

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