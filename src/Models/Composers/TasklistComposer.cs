using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.Services;

namespace Violet.Pages;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistComposer is the composer for the TasklistScene.
	(see [ComposerBase] for more details)
*/


public class TasklistComposer : ComposerBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private TaskService _taskService;
	public AppDataReadOnly appData;


	// --> 2: PROPERTIES {y}
	//


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistComposer(AppDataReadOnly appData, TaskService taskService)
	{
		this.appData = appData;
		_taskService = taskService;
	}


	// --> 4: PUBLIC METHODS {b}
	public void AddTask()
	{
		_taskService.AddTask(new Task("bbbbb", DateTime.Now, TimeSpan.FromDays(5)));
	}

	public void DeleteTask(Task task)
	{
		// pass
	}


	// --> 5: PRIVATE METHODS {v}
	//
}