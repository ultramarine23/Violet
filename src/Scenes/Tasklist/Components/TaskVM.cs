using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Models;
using Violet.Utils;

namespace Violet.ViewModels;

public partial class TaskViewModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	//


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

	// --> VM-only properties
	public string DateDueString => DateFormatter.GetRelativeDate(DateDue);
	public string DateCreatedString => DateCreated.ToString("ddd, MMMM dd");
	public string EstTimeString => EstimatedTime.ToString();


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TaskViewModel(Task task)
	{
		Description = task.Data.Description;
		DateDue = task.Data.DateDue;
		DateCreated = task.Data.DateCreated;
		EstimatedTime = task.Data.EstimatedTime;
		Uuid = task.Uuid;
	}

	public override void Dispose()
	{
		// nothing to destruct
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	//


}
