using System;

namespace Violet.Models;

/* {#fff}
{ CLASS DESCRIPTION }
	Backend model of a task.
*/


public enum TaskState
{
	COMPLETED,
	IN_PROGRESS,
	BACKLOG,
}


public class Task
{
	// --> 1: INTERNALS {r}
	

	
	// --> 2: PROPERTIES {y}
	public Guid Uuid { get; }

	// data that is non-state related is stored in TaskData, in order for
	// editing to be easier to implement (just replace the TaskData)
	public TaskData Data { get; set; }
	public TaskState State { get; set; }

	public DateTime TrueDateDue => Data.DateDue.Subtract(Data.EstimatedTime);


	// --> 3: CONSTRUCTORS {g}
	// initialize from TaskData
	public Task(TaskData taskData)
	{
		Data = taskData;
		State = TaskState.BACKLOG;
	}


	// --> 4: PUBLIC METHODS {b}
	// called via TaskService when the task data is updated
	public void EditTaskDetails(TaskData taskData)
	{
		Data = taskData;
	}

	// called via TaskService when the checkbox in the TaskView is ticked
	public void MarkAsDone()
	{
		State = TaskState.COMPLETED;
	}




	// --> 5: INTERNAL METHODS {v}
	//
}