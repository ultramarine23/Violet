using System;

namespace Violet.Models;

public class Task
{
	public string description;
	public DateTime dateDue;
	public DateTime dateCreated;
	public TimeSpan estimatedTime;
	public Guid uuid;

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
		uuid = Guid.CreateVersion7();
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