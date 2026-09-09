using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.Services;

namespace Violet.Pages;

public class TasklistComposer : ComposerBase
{
	private TaskService _taskService;
	
	public readonly AppData appData;


	public TasklistComposer(AppData appData, TaskService taskService)
	{
		this.appData = appData;
		_taskService = taskService;
	}


	public void AddTask()
	{
		_taskService.AddTask(new Task("bbbbb", DateTime.Now, TimeSpan.FromDays(5)));
	}


	public void DeleteTask(Task task)
	{
		// pass
	}
}