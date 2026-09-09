using System;
using System.Collections.Generic;

namespace Violet.Utils;

public static class DateFormatter
{
	// the maximum distance to a raw until [GetRelativeDate] gives up. 
	private const int RELATIVE_THRESHOLD = 30;

	private static readonly Dictionary<int, string> englishNumbers = new()
	{
		[2] = "two", [3] = "three", [4] = "four", [5] = "five", [6] = "six",
		[7] = "seven", [8] = "eight", [9] = "nine", [10] = "ten", [11] = "eleven"
	};
	
	public static string GetRelativeDate(DateTime raw)
	{
		var prefix = "";
		var postfix = "";
		var dayString = raw.ToString("dddd");

		var currentDate = DateOnly.FromDateTime(DateTime.Now);
		var rawDate = DateOnly.FromDateTime(raw);

		// handle the cases where the raw is today/tomorrow
		if (rawDate == currentDate)
		{
			dayString = "today";
			return dayString;
		}
		else if (rawDate == currentDate.AddDays(1))
		{
			dayString = "tomorrow";
			return dayString;
		}
		

		// handle the cases where the raw is unreasonably far away
		if (rawDate.Year != currentDate.Year)
		{
			dayString = raw.ToString("yyyy");
			return dayString;
		}
		else if (rawDate > currentDate.AddDays(RELATIVE_THRESHOLD))
		{
			dayString = raw.ToString("dd MMM yyyy");
			return dayString;
		}


		// all other cases: the distance is between two days and the relative threshold
		var remainingWeekdays = 7 - (int)currentDate.DayOfWeek;
		var upcomingSunday = currentDate.AddDays(remainingWeekdays);

		if (upcomingSunday.AddDays(7) < rawDate)
		{			
			int weeksUntilDue = (rawDate.DayNumber - upcomingSunday.DayNumber) / 7;
			var englishWeeks = englishNumbers.GetValueOrDefault(weeksUntilDue, "");

			prefix = $"in {englishWeeks} ";
			postfix = "s";
		}
		else if (upcomingSunday < rawDate)
		{
			prefix = "next ";
		}
		else
		{
			prefix = "this ";
		}

		return $"{prefix}{dayString}{postfix}";
	}
}