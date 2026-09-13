using System;
using Violet.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Services;

namespace Violet.ViewModels;

public partial class TaskAdderViewModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly AppDataReadOnly _appData;
	private readonly TaskService _taskService;


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private string _newDescription;
	

	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskAdderViewModel(TaskService taskService)
	{
		_taskService = taskService;

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
			DateTime.Now.AddDays(5),
			TimeSpan.FromHours(6)
		);
		var newTask = new Task(taskData);
		_taskService.AddTask(newTask);
	}


	// --> 5: INTERNAL METHODS {v}
	//


}
