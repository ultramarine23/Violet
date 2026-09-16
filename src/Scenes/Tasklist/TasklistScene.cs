using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	// --> 1: INTERNALS {r}
	private readonly AppDataReadOnly _readOnlyData;
	private readonly TasklistSAPI _sceneApi;
	private readonly TaskService _taskService;

	private readonly TasklistDependencies _dependencies;


	// --> 2: PROPERTIES (VMs) {y}
	public TasklistSceneViewModel SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistScene(AppDataReadOnly readOnlyData, TaskService taskService, KeybindManager keybindManager) : base(keybindManager)
	{
		_readOnlyData = readOnlyData;
		_taskService = taskService;
		_sceneApi = new TasklistSAPI(this);

		_dependencies = new TasklistDependencies(
			_readOnlyData, 
			_sceneApi, 
			_taskService
		);

		SceneVM = new TasklistSceneViewModel(_dependencies);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	//
}