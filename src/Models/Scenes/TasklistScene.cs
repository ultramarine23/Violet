using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.Services;
using Violet.ViewModels;

namespace Violet.Scenes;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistScene is the scene for the TasklistScene.
	(see [SceneBase] for more details)
*/


public class TasklistScene : SceneBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private TaskService _taskService;
	private AppDataReadOnly _appData;


	// --> 2: PROPERTIES {y}
	public ViewModelBase SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistScene(AppDataReadOnly appData, TaskService taskService)
	{
		_appData = appData;
		_taskService = taskService;

		SceneVM = new TasklistSceneViewModel(this, _appData, _taskService);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	//
}