using System;

namespace Violet.Models;

public class Task
{
	public string description;
	public DateTime dateDue;
	public DateTime dateCreated;
	public TimeSpan estimatedTime;

	public DateTime TrueDateDue
	{
		get
		{
			return dateDue.Subtract(estimatedTime);
		}
	}

	
	public Task()
	{
		// empty task creator
		description = "";
	}

	public Task(
		string pDescription, 
		DateTime pDateDue, 
		TimeSpan pEstimatedTime
	)
	{
		description = pDescription;
		dateDue = pDateDue;
		estimatedTime = pEstimatedTime;

		dateCreated = DateTime.Now;
	}
}