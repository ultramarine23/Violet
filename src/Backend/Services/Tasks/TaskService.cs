using System;
using System.Linq;
using Violet.Models;

namespace Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	TaskService is one of the AppState mutation services owned by [Backend];
	it is the bottleneck through which ALL mutations that deal with AppState.Tasks
	go through.
*/


public enum TaskSortMode
{
	CLOSEST_DUE,
	RECENTLY_CREATED,
}


public class TaskService : ServiceBase
{
	// --> 1: INTERNALS {r}	
	private readonly AppData _appData;


	// --> 2: PROPERTIES {y}
	public override string ServiceId { get; }
	public event Action? DataChanged;


	// --> 3: CONSTRUCTOR {g}
	public TaskService(AppData appData)
	{
		_appData = appData;

		ServiceId = "task";
	}


	// --> 4: PUBLIC API METHODS {b}
	public void AddTask(Task task)
	{
		_appData.Tasks.Add(task);
		DataChanged?.Invoke();
	}

	public void RemoveTask(Task task)
	{
		_appData.Tasks.Remove(task);
		DataChanged?.Invoke();
	}

	public void MoveTask(Task task, int newPosition)
	{
		var i = _appData.Tasks.IndexOf(task);
		_appData.Tasks.Move(i, newPosition);
		DataChanged?.Invoke();
	}

	public void SortTasks(TaskSortMode mode)
	{
		switch (mode)
		{
			case TaskSortMode.CLOSEST_DUE:
				_appData.Tasks.OrderBy(t => t.Data.DateDue);
				break;
			case TaskSortMode.RECENTLY_CREATED:
				_appData.Tasks.OrderBy(t => t.Data.DateCreated);
				break;
		}
		DataChanged?.Invoke();
	}

	public void MarkTaskAsCompleted(Task task)
	{
		task.ModifyState(TaskState.COMPLETED);
		DataChanged?.Invoke();
	}

	public void MarkTaskAsBacklog(Task task)
	{
		task.ModifyState(TaskState.BACKLOG);
		DataChanged?.Invoke();
	}

	public void MarkTaskAsInProgress(Task task)
	{
		task.ModifyState(TaskState.IN_PROGRESS);
		DataChanged?.Invoke();
	}

	public void EditTaskData(Task task, TaskData taskData)
	{
		task.EditTaskDetails(taskData);
		DataChanged?.Invoke();
	}


	// --> 5: INTERNAL METHODS {v}
	//
}