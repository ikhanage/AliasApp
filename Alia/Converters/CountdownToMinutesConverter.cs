using System;
using Xamarin.Forms;

namespace Alia
{
	public class CountdownToMinutesConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = TimeSpan.FromSeconds((double)value);

			if (timespan.TotalMinutes < 1.0)
			{
				return "Not a single minute to keep us apart";
			}

			return string.Format("{0:D2} Minutes", timespan.Minutes);
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

