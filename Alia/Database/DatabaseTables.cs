using SQLite;

namespace Alia
{
	public class TaskTable
	{
		[PrimaryKey] public int Id { get; set;}
		public string Name { get; set; }
		public string Text { get; set; }
		public int UnlockCode { get; set; }
		public PageTypes PageType { get; set; }
		public bool Completed { get; set; }
		public bool Locked { get; set; }

		public TaskTable(int id, TaskNames taskName, int unlockCode)
		{
			Id = id;
			Name = taskName.ToString ();
			Text = GetText.GetTextPageText (taskName);
			UnlockCode = unlockCode;
			PageType = PageTypes.TextPage;
			Completed = false;
			Locked = false;
		}
	}

	public class QuizTaskTable : TaskTable
	{
		[Indexed] public int Fk { get; set; }
		public string Response1 { get; set; }
		public string Response2 { get; set; }
		public string Response3 { get; set; }
		public string Response4 { get; set; }
		public int Answer  { get; set; }

		public QuizTaskTable (int id, TaskNames taskName, int unlockCode, string response1, string response2, string response3, string response4, int answer) : base (id, taskName, unlockCode)
		{
			Fk = id;
			Response1 = response1;
			Response2 = response2;
			Response3 = response3;
			Response4 = response4;
			Answer = answer;
			PageType = PageTypes.QuizPage;
		}
	}

	public class NavTaskTable : TaskTable
	{
		[Indexed] public int Fk { get; set; }
		public int CodeToComplete { get; set; }

		public NavTaskTable (int id, TaskNames taskName, int unlockCode, int codeToComplete) : base (id, taskName, unlockCode)
		{
			Fk = id;
			CodeToComplete = codeToComplete;
			PageType = PageTypes.NavPage;
		}
	}
}