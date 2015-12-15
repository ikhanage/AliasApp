using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alia
{
	public class QuizButtons
	{
		[JsonProperty("Answer")]
		public string Answer { get; set; }

		[JsonProperty("Buttons")]
		public List<Buttons> Buttons { get; set; }

		[JsonProperty("Question")]
		public string Question { get; set; }
	}

	public class Buttons
	{
		[JsonProperty("Text")]
		public string Text { get; set; }

		[JsonProperty("Response")]
		public string Response { get; set; }
	}
}