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
			textTasks.Add (new TextTaskTable (6, TaskNames.RhymeTime, 101, 102));

			textTasks.Add (new NavTaskTable (7, TaskNames.AmusementTime, 108, 109, 321));
			textTasks.Add (new QuizTaskTable (8, TaskNames.YouLookGoose, 105, 106));
			textTasks.Add (new TextTaskTable (9, TaskNames.ImmysLament, 106, 107));
			textTasks.Add (new TextTaskTable (10, TaskNames.AShortMessage, 107, 108));

			textTasks.Add (new NavTaskTable (11, TaskNames.Luncheon, 108, 109, 321));
			textTasks.Add (new TextTaskTable (12, TaskNames.InitialPlan, 109, 201));
			textTasks.Add (new TextTaskTable (13, TaskNames.ChildOfJuly, 201, 202));
			textTasks.Add (new QuizTaskTable (14, TaskNames.HowMuchILoveYou, 202, 203));
			textTasks.Add (new QuizTaskTable (15, TaskNames.ImmyQuiz, 203, 204));

			textTasks.Add (new NavTaskTable (16, TaskNames.ToThePark, 108, 109, 321));
			textTasks.Add (new QuizTaskTable (17, TaskNames.AKinderQuestion, 205, 206));
			textTasks.Add (new QuizTaskTable (18, TaskNames.AFollowUpQuestion, 206, 207));
			textTasks.Add (new QuizTaskTable (19, TaskNames.TheEnd, 207, 000));
			return textTasks;
		}
	}
}