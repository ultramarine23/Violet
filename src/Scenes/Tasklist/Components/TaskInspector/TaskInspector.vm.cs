using System;
using Violet.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Services;
using System.Collections.ObjectModel;
using Violet.Scenes;
using System.Collections.Specialized;
using System.Linq;

namespace Violet.ViewModels;

public partial class TaskInspectorViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly TasklistDependencies _dependencies;


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private KanbanColumnViewModel _priorityColumnVM;

	[ObservableProperty]
	private KanbanColumnViewModel _progressColumnVM;

	[ObservableProperty]
	private KanbanColumnViewModel _backlogColumnVM;
	


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskInspectorViewModel(TasklistDependencies dependencies)
	{
		_dependencies = dependencies;

		PriorityColumnVM = new(_dependencies);
		ProgressColumnVM = new(_dependencies);
		BacklogColumnVM = new(_dependencies);
	}

	public override void Dispose()
	{
		// na
	}


	// --> 4: RELAY COMMANDS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	//


}
