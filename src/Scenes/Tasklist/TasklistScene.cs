using System;
using System.Collections.Generic;
using Avalonia.Input;
using Violet.Models;
using Violet.Services;
using Violet.ViewModels;

namespace Violet.Scenes;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistScene is the scene for the Tasklist tab.
	(see [SceneBase] for more details)
*/


public class TasklistScene : SceneBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	// inherits AppDataReadOnly _readOnlyData;


	// --> 2: PROPERTIES {y}
	public TaskService TaskService { get; }
	public ViewModelBase SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistScene(AppDataReadOnly readOnlyData, TaskService taskService) : base(readOnlyData)
	{
		TaskService = taskService;
		SceneVM = new TasklistSceneViewModel(this, readOnlyData, TaskService);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	//
}