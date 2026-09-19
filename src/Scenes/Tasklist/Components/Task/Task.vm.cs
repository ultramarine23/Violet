using System;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Models;
using Violet.Scenes;
using Violet.Utils;

namespace Violet.ViewModels;

public partial class TaskViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly TasklistDependencies _dependencies;
	private readonly Task _task;


	// --> 2: PROPERTIES {y}
	public Guid Uuid { get; private set; }
	
	[ObservableProperty]
	private string _description;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(DateDueString))]
	[NotifyPropertyChangedFor(nameof(TimeDueString))]
	private DateTime _dateDue;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(EstTimeString))]
	private TimeSpan _estimatedTime;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsMarkedDone))]
	private TaskState _currentState;

	[ObservableProperty]
	private bool _readMode;

	// --> VM-only properties
	// note: dependent/calculated properties use [NotifyPropertyChangedFor]
	// instead of an [ObservableProperty] of their own
	public string DateDueString => DateFormatter.GetRelativeDate(DateDue);
	public string TimeDueString => DateDue.ToString("t");
	public string EstTimeString => FormatEstimatedTimeString();
	public bool IsMarkedDone => CurrentState == TaskState.COMPLETED;

	public event Action? EditStateEnded;


	// --> 3: INIT & SYNCHRONIZAION {g}
	public TaskViewModel(TasklistDependencies dependencies, Task task)
	{
		_dependencies = dependencies;
		_task = task;

		// initialize all properties; heed not the squiggly yellow line!		
		RefreshData();
		ReadMode = true;
		_dependencies.TaskService.DataChanged += RefreshData;
	}

	public override void Dispose()
	{
		_dependencies.TaskService.DataChanged -= RefreshData;
	}

	private void RefreshData()
	{
		Description = _task.Data.Description;
		DateDue = _task.Data.DateDue;
		EstimatedTime = _task.Data.EstimatedTime;
		CurrentState = _task.State;
		Uuid = _task.Uuid;
	}
 

	// --> 4: RELAY METHODS {b}
	[RelayCommand]
	public void DeleteSelf()
	{
		_dependencies.TaskService.RemoveTask(_task);
	}

	[RelayCommand]
	public void StartEdit()
	{
		ReadMode = false;

		_dependencies.SceneApi.RegisterKeybind(
			new KeyGesture(Key.Enter),
			EndEdit
		);
		_dependencies.SceneApi.RegisterKeybind(
			new KeyGesture(Key.Delete),
			DeleteSelf
		);
	}

	public void EndEdit()
	{
		// stop ReadMode and unregister keybinds
		ReadMode = true;

		_dependencies.SceneApi.UnregisterKeybind(
			new KeyGesture(Key.Enter),
			EndEdit
		);
		_dependencies.SceneApi.UnregisterKeybind(
			new KeyGesture(Key.Delete),
			DeleteSelf
		);

		EditStateEnded?.Invoke();

		// mutate the task state {white, 8}
		_dependencies.TaskService.EditTaskData(
			_task,
			new TaskData(
				Description,
				_task.Data.DateDue,
				_task.Data.EstimatedTime
			)
		);
	}

	[RelayCommand]
	public void ToggleCompletedState(bool toggleOn)
	{
		if (toggleOn == true)
		{
			_dependencies.TaskService.MarkTaskAsCompleted(_task);
		}
		else
		{
			_dependencies.TaskService.MarkTaskAsBacklog(_task);
		}
	}
	

	// --> 5: INTERNAL METHODS {v}
	private string FormatEstimatedTimeString()
	{
		var hours = (int)EstimatedTime.TotalHours;
		var minutes = EstimatedTime.Minutes;

		if (hours >= 100)
		{
			return "over 100 hours";
		}

		if (minutes != 0)
		{
			return $"reserve {hours} hours and {minutes} mins";
		}
		else
		{
			return $"reserve {hours} hours";
		}
	}


}
