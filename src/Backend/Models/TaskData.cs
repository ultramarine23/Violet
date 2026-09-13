using System;

namespace Violet.Models;

public class TaskData
{
	public string Description 	  { get; set; }
	public DateTime DateDue 	  { get; set; }
	public DateTime DateCreated   { get; set; }
	public TimeSpan EstimatedTime { get; set; }
	public bool IsMarkedDone 	  { get; set; }

	public TaskData(
		string description,
		DateTime dateDue,
		TimeSpan estimatedTime
	)
	{
		Description = description;
		DateDue = dateDue;
		DateCreated = DateTime.Now;
		EstimatedTime = estimatedTime;
		IsMarkedDone = false;
	}

	
}