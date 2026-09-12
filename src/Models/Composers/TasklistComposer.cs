using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.Services;
using Violet.ViewModels;

namespace Violet.Scenes;

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
	public ViewModelBase SceneModel { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistComposer(AppDataReadOnly appData, TaskService taskService)
	{
		this.appData = appData;
		_taskService = taskService;

		SceneModel = new TasklistSceneModel(this, _taskService);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	//
}