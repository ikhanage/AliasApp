﻿using System.Collections.Generic;

namespace Alia
{
	public static class SetUpDatabaseTasks
	{
		public static List<TextTaskTable> SetUpTextTask()
		{
			var textTasks = new List<TextTaskTable> ();

			var taskTask = new TextTaskTable (1, TaskNames.OneYear, 000, 101);
			taskTask.Locked = false;

			textTasks.Add (taskTask);
			textTasks.Add (new TextTaskTable (2, TaskNames.TheHuntBegins, 101, 102));
			return textTasks;
		}

		public static List<NavTaskTable> SetUpNavTasks()
		{
			var navTasks = new List<NavTaskTable> ();

			//navTasks.Add (new NavTaskTable(3, TaskNames.TextTest, 003, 004, 321));
			return navTasks;
		}

		public static List<QuizTaskTable> SetUpQuizTasks()
		{
			var quizTasks = new List<QuizTaskTable> ();

			quizTasks.Add (new QuizTaskTable (3, TaskNames.WhatGoesUp, 102, 103));
			quizTasks.Add (new QuizTaskTable (4, TaskNames.AVerySeriousQuestion, 103, 104));
			quizTasks.Add (new QuizTaskTable (5, TaskNames.SoVeryStuck, 104, 105));
			quizTasks.Add (new QuizTaskTable (6, TaskNames.YouLookGoose, 105, 106));
			return quizTasks;
		}
	}
}