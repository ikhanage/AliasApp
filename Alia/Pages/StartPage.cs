using Xamarin.Forms;

namespace Alia
{
	public class StartPage : ContentPage
	{
		Entry numberInput1;
		Entry numberInput2;
		Entry numberInput3;

		Countdown countdown;

		public StartPage ()
		{
			numberInput1 = new NumberPicker(); 
        	numberInput2 = new NumberPicker();
         	numberInput3 = new NumberPicker(); 

			countdown = new Countdown ();
			var countdownDay = GetCountdownLabel ();
			var countdownHours = GetCountdownLabel ();
			var countdownMinutes = GetCountdownLabel ();
			var countdownSeconds = GetCountdownLabel ();

			var introText = GetIntroLabel ();
			var grid = GetGrid ();
					
			countdown.StartUpdating ();

			introText.SetBinding(Label.TextProperty, new Binding("IntroText"));
			introText.BindingContext = countdown;
			introText.TextColor = Color.White;

			countdownDay.SetBinding(Label.TextProperty,
				new Binding("RemainTime", BindingMode.Default, new CountdownToDayConverter()));
			countdownDay.BindingContext = countdown;

			countdownHours.SetBinding(Label.TextProperty,
				new Binding("RemainTime", BindingMode.Default, new CountdownToHoursConverter()));
			countdownHours.BindingContext = countdown;

			countdownMinutes.SetBinding(Label.TextProperty,
				new Binding("RemainTime", BindingMode.Default, new CountdownToMinutesConverter()));
			countdownMinutes.BindingContext = countdown;

			countdownSeconds.SetBinding(Label.TextProperty,
				new Binding("RemainTime", BindingMode.Default, new CountdownToSecondsConverter()));
			countdownSeconds.BindingContext = countdown;

			SetInputBindings ();

			grid.Children.Add (countdownDay, 0, 3, 0, 1);
			grid.Children.Add (countdownHours, 0, 3, 1, 2);
			grid.Children.Add (countdownMinutes, 0, 3, 2, 3);
			grid.Children.Add (countdownSeconds, 0, 3, 3, 4);
			grid.Children.Add (introText, 0, 3, 4, 5);
			grid.Children.Add (numberInput1, 0, 1, 5, 6);
			grid.Children.Add (numberInput2, 1, 2, 5, 6);
			grid.Children.Add (numberInput3, 2, 3, 5, 6);

			BackgroundImage = AppSettings.AppBackgroundImage;

			Content = grid;
		}

		void SetInputBindings ()
		{
			numberInput1.SetBinding (VisualElement.IsVisibleProperty, new Binding ("ShowInput"));
			numberInput1.BindingContext = countdown;

			numberInput2.SetBinding (VisualElement.IsVisibleProperty, new Binding ("ShowInput"));
			numberInput2.BindingContext = countdown;

			numberInput3.SetBinding (VisualElement.IsVisibleProperty, new Binding ("ShowInput"));
			numberInput3.BindingContext = countdown;

			numberInput1.Focused += NumberInput1_Focused;
			numberInput2.Focused += NumberInput2_Focused;
			numberInput3.Focused += NumberInput3_Focused;

			numberInput1.TextChanged += NumberInput1_TextChanged;
        	numberInput2.TextChanged += NumberInput2_TextChanged;
         	numberInput3.TextChanged += NumberInput3_TextChanged;
						
			numberInput1.TextChanged += NumberInput_SelectedIndexChanged;
			numberInput2.TextChanged += NumberInput_SelectedIndexChanged;
			numberInput3.TextChanged += NumberInput_SelectedIndexChanged;
		}

		void NumberInput3_Focused (object sender, FocusEventArgs e)
		{
			if(!CorrectInput ())
				numberInput3.Text = string.Empty;
		}

		void NumberInput2_Focused (object sender, FocusEventArgs e)
		{
			if(!CorrectInput ())
				numberInput2.Text = string.Empty;
		}

		void NumberInput1_Focused (object sender, FocusEventArgs e)
		{
			if(!CorrectInput ())
			numberInput1.Text = string.Empty;
		}

		void NumberInput3_TextChanged (object sender, TextChangedEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(e.NewTextValue))
				numberInput1.Focus ();
		}

		void NumberInput2_TextChanged (object sender, TextChangedEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(e.NewTextValue))
				numberInput3.Focus ();
		}

		void NumberInput1_TextChanged (object sender, TextChangedEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(e.NewTextValue))
				numberInput2.Focus ();
		}

		void NumberInput_SelectedIndexChanged (object sender, System.EventArgs e)
		{
			CorrectInput ();
		}

		bool CorrectInput ()
		{
			var correctInput1 = numberInput1.Text == "3";
			var correctInput2 = numberInput2.Text == "2";
			var correctInput3 = numberInput3.Text == "1";

			if (correctInput1 && correctInput2 && correctInput3) 
			{
				Navigation.PushModalAsync (new TasksPage());
				return true;
			}

			return false;
		}

		static Label GetIntroLabel ()
		{
			return new Label 
			{ 
				Text = "Alia's birthday in",
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
		}

		static Label GetCountdownLabel()
		{
			return new Label {
				Text = "Hello ContentPage",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.White
			};			
		}

		static Grid GetGrid()
		{
			return new Grid 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				Padding = new Thickness (10, 1, 10, 1),
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Star) }
				}
			};
		}
	}
}