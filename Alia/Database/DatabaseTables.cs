﻿using SQLite;
using System.Text.RegularExpressions;

namespace Alia
{
	public class TextTaskTable
	{
		[PrimaryKey] public int Id { get; set;}
		public string Name { get; set; }
		public string Text { get; set; }
		public int UnlockCode { get; set; }
		public int NextTaskUnlockCode { get; set; }
		public PageTypes PageType { get; set; }
		public bool Completed { get; set; }
		public bool Locked { get; set; }

		public TextTaskTable(int id, TaskNames taskName, int unlockCode, int nextTaskUnlockCode)
		{
			Id = id;
			Name = EnumToTitle (taskName);
			Text = GetText.GetTextPageText (taskName);
			UnlockCode = unlockCode;
			PageType = PageTypes.TextPage;
			Completed = false;
			Locked = true;
			NextTaskUnlockCode = nextTaskUnlockCode;
		}

		public TextTaskTable(){}

		static string EnumToTitle(TaskNames taskName)
		{
			var regex = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

			return regex.Replace (taskName.ToString(), " ");
		}
	}

	public class QuizTaskTable : TextTaskTable
	{
		[Indexed] public int Fk { get; set; }
		public string Response1 { get; set; }
		public string Response2 { get; set; }
		public string Response3 { get; set; }
		public string Response4 { get; set; }
		public string ResponseText1 { get; set; }
		public string ResponseText2 { get; set; }
		public string ResponseText3 { get; set; }
		public string ResponseText4 { get; set; }
		public int Answer  { get; set; }

		public QuizTaskTable (int id, TaskNames taskName, int unlockCode, int nextTaskUnlockCode, string response1, string response2, string response3, string response4, string responseText1, string responseText2, string responseText3, string responseText4, int answer) : base (id, taskName, unlockCode, nextTaskUnlockCode)
		{
			Fk = id;
			Response1 = response1;
			Response2 = response2;
			Response3 = response3;
			Response4 = response4;
			ResponseText1 = responseText1;
			ResponseText2 = responseText2;
			ResponseText3 = responseText3;
			ResponseText4 = responseText4;
			Answer = answer;
			PageType = PageTypes.QuizPage;
		}

		public QuizTaskTable(){}
	}

	public class NavTaskTable : TextTaskTable
	{
		[Indexed] public int Fk { get; set; }
		public int CodeToComplete { get; set; }

		public NavTaskTable (int id, TaskNames taskName, int unlockCode, int nextTaskUnlockCode, int codeToComplete) : base (id, taskName, unlockCode, nextTaskUnlockCode)
		{
			Fk = id;
			CodeToComplete = codeToComplete;
			PageType = PageTypes.NavPage;
		}

		public NavTaskTable(){}
	}
}