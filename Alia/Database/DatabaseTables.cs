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
	}

	public class QuizTaskTable : TaskTable
	{
		[Indexed] public int Fk { get { return Id; } }
		public string Response1 { get; set; }
		public string Response2 { get; set; }
		public string Response3 { get; set; }
		public string Response4 { get; set; }
		public int Answer  { get; set; }
	}

	public class NavTaskTable : TaskTable
	{
		[Indexed] public int Fk { get { return Id; } }
		public int CodeToComplete { get; set; }
	}
}