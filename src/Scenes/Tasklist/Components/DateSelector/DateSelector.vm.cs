using System;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public partial class DateSelectorViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	// this is a TRUE COMPONENT, therefore it doesnt have any dependencies


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(DateSelectedString))]
	private DateOnly _dateSelected;

	public string DateSelectedString => DateSelected.ToString("ddd, MMM dd");


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public DateSelectorViewModel()
	{
		DateSelected = DateOnly.FromDateTime(DateTime.Now);
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
