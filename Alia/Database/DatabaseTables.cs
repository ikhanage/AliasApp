using SQLite;
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

		public QuizTaskTable (int id, TaskNames taskName, int unlockCode, int nextTaskUnlockCode) : base (id, taskName, unlockCode, nextTaskUnlockCode)
		{
			Fk = id;
			var button = GetText.GetQuizButtons (taskName);
			Response1 = button.Buttons[0].Text;
			Response2 = button.Buttons[1].Text;
			Response3 = button.Buttons[2].Text;
			Response4 = button.Buttons[3].Text;
			ResponseText1 = button.Buttons[0].Response;
			ResponseText2 = button.Buttons[1].Response;
			ResponseText3 = button.Buttons[2].Response;
			ResponseText4 = button.Buttons[3].Response;
			Answer = int.Parse (button.Answer);
			Text = button.Question;
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