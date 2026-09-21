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

	[ObservableProperty]
	private DateTime? _newDateDue;

	[ObservableProperty]
	private TimeSpan _newTimeDue;

	public DateTime DateNow => DateTime.Now;

	public TimeSelectorViewModel TimeSelectorVM { get; }
	public DateSelectorViewModel DateSelectorVM { get; }
	public TimespanSelectorViewModel TimespanSelectorVM { get; }
	

	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskAdderViewModel(TasklistDependencies dependencies)
	{
		_dependencies = dependencies;

		NewDescription = "";
		NewDateDue = null;
		NewTimeDue = new TimeSpan();

		TimeSelectorVM = new TimeSelectorViewModel();
		DateSelectorVM = new DateSelectorViewModel();
		TimespanSelectorVM = new TimespanSelectorViewModel();
	}

	public override void Dispose()
	{
		// nothing to destruct
	}


	// --> 4: RELAY COMMANDS {b}
	[RelayCommand]
	public void AddTask()
	{
		// compiler keeps crying that NewDateDue isnt a DateTime, even
		// when i introduce a null guard -.- im probs just stupid L bozo
		if (NewDateDue is DateTime dateDue)
		{
			var taskData = new TaskData(
				NewDescription,
				dateDue.Add(NewTimeDue),
				TimeSpan.FromHours(6)
			);

			var newTask = new Task(taskData);
			_dependencies.TaskService.AddTask(newTask);
		}
	}


	// --> 5: INTERNAL METHODS {v}
	


}
