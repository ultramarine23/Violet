using System;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public partial class TimespanSelectorViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	// this is a TRUE COMPONENT, therefore it doesnt have any dependencies


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(TimespanSelectedString))]
	private TimeSpan _timespanSelected;

	public string TimespanSelectedString => StringifyTimespan(TimespanSelected);


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TimespanSelectorViewModel()
	{
		TimespanSelected = TimeSpan.FromMinutes(30);
	}

	public override void Dispose()
	{
		// na
	}


	// --> 4: RELAY COMMANDS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	private string StringifyTimespan(TimeSpan input)
	{
		if (input.Hours != 0)
		{
			return $"{input.Hours} hours {input.Minutes} minutes";
		}
		else
		{
			return $"{input.Minutes} minutes";
		}
	}


}
