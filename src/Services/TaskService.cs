using System;
using Violet.Models;

namespace Violet.Services;

public class TaskService
{
	private AppData _appData;

	public event EventHandler<Task>? TaskAddedEvent;

	
	public TaskService(AppData appData)
	{
		_appData = appData;
	}


	public void AddTask(Task task)
	{
		_appData.Tasks.Add(task);

		// publish an event to synchronize UI elements
		TaskAddedEvent?.Invoke(this, task);
	}
}