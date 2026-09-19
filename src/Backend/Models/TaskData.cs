using System;
using System.Collections.Generic;

namespace Violet.Models;


public class TaskData
{
	public string Description 	  { get; }
	public DateTime DateDue 	  { get; }
	public DateTime DateCreated   { get; }
	public TimeSpan EstimatedTime { get; }
	public List<string> Tags	  { get; }


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
		Tags = [];
	}

	
}