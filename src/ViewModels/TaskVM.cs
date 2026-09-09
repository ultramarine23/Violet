using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Models;
using Violet.Utils;

namespace Violet.ViewModels;

public partial class TaskViewModel : ViewModelBase
{
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

	public TaskViewModel(Task task)
	{
		Description = task.description;
		DateDue = task.dateDue;
		DateCreated = task.dateCreated;
		EstimatedTime = task.estimatedTime;
	}

}
