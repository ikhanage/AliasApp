using System.Collections.Generic;

namespace Alia
{
	public static class SetUpDatabaseTasks
	{
		public static List<TextTaskTable> SetUpTextTask()
		{
			var textTasks = new List<TextTaskTable> ();

			textTasks.Add (new TextTaskTable (1, TaskNames.OneYear, 000, 101){ Locked = false });
			textTasks.Add (new TextTaskTable (2, TaskNames.TheHuntBegins, 101, 102));
			textTasks.Add (new QuizTaskTable (3, TaskNames.WhatGoesUp, 102, 103));
			textTasks.Add (new QuizTaskTable (4, TaskNames.AVerySeriousQuestion, 103, 104));
         	textTasks.Add (new QuizTaskTable (5, TaskNames.SoVeryStuck, 104, 105));
         	textTasks.Add (new QuizTaskTable (6, TaskNames.YouLookGoose, 105, 106));
			textTasks.Add (new TextTaskTable (7, TaskNames.ImmysLament, 106, 107));
			textTasks.Add (new TextTaskTable (8, TaskNames.AShortMessage, 107, 108));
			textTasks.Add (new NavTaskTable (9, TaskNames.Luncheon, 108, 109, 321));
			textTasks.Add (new TextTaskTable (10, TaskNames.InitialPlan, 102, 201));

			return textTasks;
		}
	}
}