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
	public Guid Uuid { get; }
	
	[ObservableProperty]
	private string _description;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(DateDueString))]
	private DateTime _dateDue;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(DateCreatedString))]
	private DateTime _dateCreated;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(EstTimeString))]
	private TimeSpan _estimatedTime;

	[ObservableProperty]
	private bool _readMode;

	// --> VM-only properties
	public string DateDueString => DateFormatter.GetRelativeDate(DateDue);
	public string DateCreatedString => DateCreated.ToString("ddd, MMMM dd");
	public string EstTimeString => FormatEstimatedTimeString();
	public string RemainingTimeString => FormatRemainingTimeString();

	public event Action? EditStateEnded;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskViewModel(TasklistDependencies dependencies, Task task)
	{
		_dependencies = dependencies;
		_task = task;

		Description = task.Data.Description;
		DateDue = task.Data.DateDue;
		DateCreated = task.Data.DateCreated;
		EstimatedTime = task.Data.EstimatedTime;
		Uuid = task.Uuid;

		ReadMode = true;
	}

	public override void Dispose()
	{
		// nothing to destruct
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
		ReadMode = true;

		_dependencies.SceneApi.UnregisterKeybind(
			new KeyGesture(Key.Enter),
			EndEdit
		);
		_dependencies.SceneApi.UnregisterKeybind(
			new KeyGesture(Key.Delete),
			DeleteSelf
		);

		EditStateEnded.Invoke();
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

	private string FormatRemainingTimeString()
	{
		var remainingSpan = DateDue.Subtract(DateCreated) - EstimatedTime;
		var formatted = $"latest start at {(int)remainingSpan.TotalHours}:{remainingSpan.Minutes}:{remainingSpan.Seconds}";

		if (remainingSpan.TotalHours > 100)
		{
			formatted = "latest start >100 hours away";
		}
		return formatted;
	}

}
