using System;
using Xamarin.Forms;

namespace Alia
{
	public class QuizTaskView : TextTaskView
	{
		readonly int Answer;
		readonly TaskLabel ResponseText;

		public QuizTaskView (QuizTaskTable quizTask) : base (quizTask)
		{
			Answer = quizTask.Answer;
			AnswerLabel.Text = string.Empty;
			AnswerAndReturnButton.IsVisible = false;

			ResponseText = new TaskLabel ();

			var taskButton1 = new TaskButtons (quizTask.Response1, quizTask.ResponseText1, 1);
         	var taskButton2 = new TaskButtons (quizTask.Response2, quizTask.ResponseText2, 2);
			var taskButton3 = new TaskButtons (quizTask.Response3, quizTask.ResponseText3, 3);
			var taskButton4 = new TaskButtons (quizTask.Response4, quizTask.ResponseText4, 4);

			taskButton1.Clicked += AnswerTap;
         	taskButton2.Clicked += AnswerTap;
         	taskButton3.Clicked += AnswerTap;
         	taskButton4.Clicked += AnswerTap;

			if(!string.IsNullOrWhiteSpace(taskButton1.Text))
				Children.Add (taskButton1);
			
			if(!string.IsNullOrWhiteSpace(taskButton2.Text))
				Children.Add (taskButton2);
			
			if(!string.IsNullOrWhiteSpace(taskButton3.Text))
				Children.Add (taskButton3);
			
			if(!string.IsNullOrWhiteSpace(taskButton4.Text))
				Children.Add (taskButton4);
			
			Children.Add (ResponseText);
			Children.Add (AnswerLabel);
		}

		void AnswerTap (object sender, EventArgs e)
		{
			var task = (TaskButtons) sender;
			task.IsVisible = false;

			ResponseText.Text = task.ResponseText;

			if (Answer == task.ButtonId || Answer == 0) {
				AnswerLabel.Text = NextTaskUnlockCode;
				AnswerAndReturnButton.IsVisible = true;
			}
		}
	}
}