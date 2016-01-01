using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Alia
{
	public class Countdown : INotifyPropertyChanged
	{
		public event Action Completed;
		public event Action Ticked;

		double remainTime;
		bool showInput;
		string introText;
		DateTime aliasBirthday{ get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public string IntroText
		{
			get { return introText; }

			private set
			{
				introText = value;
				OnPropertyChanged ();
			}
		}

		bool IsPartyTime
		{
			get { return RemainTime < 1; }
		}

		public DateTime AliasBirthday 
		{ 
			get 
			{ 
				return aliasBirthday;
			}
			set
			{
				aliasBirthday = value;
			}
		}

		public double RemainTime
		{
			get { return remainTime; }

			private set
			{
				remainTime = value;
				OnPropertyChanged();
			}
		}

		public bool ShowInput
		{
			get { return showInput; }

			private set
			{
				showInput = value;
				OnPropertyChanged ();
			}
		}

		public void StartUpdating()
		{
			AliasBirthday = new DateTime (2016, 7, 16, 9, 0, 0); 
			#if DEBUG
			AliasBirthday = DateTime.Now.AddSeconds(5);
			#endif

			var timeRemaining = (AliasBirthday - DateTime.Now).TotalSeconds;
			RemainTime = timeRemaining;

			var timeSpan = new TimeSpan (0, 0, 0, 0, 1000);
			Xamarin.Forms.Device.StartTimer (timeSpan, Tick);
		}

		public bool Tick()
		{
			var delta =  (AliasBirthday - DateTime.Now).TotalSeconds;

			if (delta < RemainTime)
			{
				RemainTime -= (RemainTime - delta);
				SetInputVisibility ();
				SetIntoText ();

				var ticked = Ticked;
				if (ticked != null)
				{
					ticked();
					return true;
				}
			}
			else
			{
				RemainTime = 0;

				var completed = Completed;
				if (completed != null)
				{
					ShowInput = true;
					completed();
					return false;
				}
			}

			return true;
		}

		void SetInputVisibility ()
		{
			ShowInput = IsPartyTime;
		}

		void SetIntoText(){
			if (IsPartyTime)
				IntroText = "It's been a year!";
			else
				IntroText = "Until it's been a year";

		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

