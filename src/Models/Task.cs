using System;

namespace Violet.Models;

/* {#fff}
{ CLASS DESCRIPTION }
	Backend model of a task.
*/


public class Task
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	

	
	// --> 2: PROPERTIES {y}
	public Guid Uuid { get; }

	public string Description 	  { get; private set; }
	public DateTime DateDue 	  { get; private set; }
	public DateTime DateCreated   { get; private set; }
	public TimeSpan EstimatedTime { get; private set; }
	public bool IsMarkedDone 	  { get; private set; }
	
	public DateTime TrueDateDue => DateDue.Subtract(EstimatedTime);


	// --> 3: CONSTRUCTORS {g}
	// create new task at current time
	public Task(
		string description, 
		DateTime dateDue, 
		TimeSpan estimatedTime
	)
	{
		Description = description;
		DateDue = dateDue;
		EstimatedTime = estimatedTime;

		DateCreated = DateTime.Now;
		IsMarkedDone = false;
	}

	// recreate existing task (for loading saved tasks, probs)
	public Task(
		string description, 
		DateTime dateDue, 
		TimeSpan estimatedTime,
		DateTime dateCreated,
		bool isMarkedDone
	)
	{
		Description = description;
		DateDue = dateDue;
		EstimatedTime = estimatedTime;
		DateCreated = dateCreated;
		IsMarkedDone = isMarkedDone;
	}


	// --> 4: PUBLIC METHODS {b}
	// called via TaskService when the task data is updated
	public void EditTaskDetails(
		string description, 
		DateTime dateDue, 
		TimeSpan estimatedTime,
		DateTime dateCreated
	)
	{
		Description = description;
		DateDue = dateDue;
		EstimatedTime = estimatedTime;
		DateCreated = dateCreated;
	}

	// called via TaskService when the checkbox in the TaskView is ticked
	public void MarkAsDone()
	{
		IsMarkedDone = true;
	}


	// --> 5: INTERNAL METHODS {v}
	//
}