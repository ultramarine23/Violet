using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Models;
using Violet.Scenes;
using Violet.Services;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistSceneViewModel is the VM connecting the TasklistScene 
	and TasklistScene.
*/


public partial class TasklistSceneViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly TasklistDependencies _dependencies;
	

	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private TaskAdderViewModel _taskAdderVM;

	[ObservableProperty]
	private TaskInspectorViewModel _taskInspectorVM;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistSceneViewModel(TasklistDependencies dependencies)
	{
		_dependencies = dependencies;
		
		TaskAdderVM = new TaskAdderViewModel(dependencies);
		TaskInspectorVM = new TaskInspectorViewModel(dependencies);
	}

	public override void Dispose()
	{
		// nothing to destruct
	}


	// --> 4: RELAY METHODS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	//


}
