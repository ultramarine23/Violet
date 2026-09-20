using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public partial class TimeSelectorViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	// this is a TRUE COMPONENT, therefore it doesnt have any dependencies


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private TimeOnly _timeSelected;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TimeSelectorViewModel()
	{
		_timeSelected = TimeOnly.Parse("12:00AM");
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
