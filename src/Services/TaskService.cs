using System;
using System.Linq;
using Microsoft.VisualBasic;
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


public class TaskService
{
	// --> 1: INTERNALS {r}	
	private readonly AppData _appData;


	// --> 2: PROPERTIES {y}
	//


	// --> 3: CONSTRUCTOR {g}
	public TaskService(AppData appData)
	{
		_appData = appData;
	}


	// --> 4: PUBLIC API METHODS {b}
	public void AddTask(Task task)
	{
		_appData.Tasks.Add(task);
	}

	public void RemoveTask(Task task)
	{
		_appData.Tasks.Remove(task);
	}

	public void MoveTask(Task task, int newPosition)
	{
		var i = _appData.Tasks.IndexOf(task);
		_appData.Tasks.Move(i, newPosition);
	}

	public void SortTasks(TaskSortMode mode)
	{
		switch (mode)
		{
			case TaskSortMode.CLOSEST_DUE:
				_appData.Tasks.OrderBy(t => t.DateDue);
				break;
			case TaskSortMode.RECENTLY_CREATED:
				_appData.Tasks.OrderBy(t => t.DateCreated);
				break;
		}
	}

	public void MarkTaskAsDone(Task task)
	{
		task.MarkAsDone();
	}


	// --> 5: INTERNAL METHODS {v}
	//
}