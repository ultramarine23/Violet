using System;
using Violet.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Services;
using Violet.Scenes;

namespace Violet.ViewModels;

public partial class TaskAdderViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly TasklistDependencies _dependencies;


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private string _newDescription;
	

	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskAdderViewModel(TasklistDependencies dependencies)
	{
		_dependencies = dependencies;

		NewDescription = "";
	}

	public override void Dispose()
	{
		// nothing to destruct
	}


	// --> 4: RELAY COMMANDS {b}
	[RelayCommand]
	public void AddTask()
	{
		var taskData = new TaskData(
			NewDescription,
			DateTime.Now.AddDays(3),
			TimeSpan.FromHours(6)
		);

		var newTask = new Task(taskData);
		_dependencies.TaskService.AddTask(newTask);
	}


	// --> 5: INTERNAL METHODS {v}
	


}
