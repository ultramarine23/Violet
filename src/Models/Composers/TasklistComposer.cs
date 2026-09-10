using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.Services;

namespace Violet.Pages;

public class TasklistComposer : ComposerBase
{
	private TaskService _taskService;
	
	public AppDataReadOnly appData;


	public TasklistComposer(AppDataReadOnly appData, TaskService taskService)
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