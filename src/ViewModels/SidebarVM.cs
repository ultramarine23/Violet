using System;
using System.Collections.Generic;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Pages;
using Violet.Services;

namespace Violet.ViewModels;

public partial class SidebarViewModel : ViewModelBase
{

	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly NavigationService _navigation;


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private bool _tasklistNavigable;

	[ObservableProperty]
	private bool _calendarNavigable;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public SidebarViewModel(NavigationService navigation)
	{
		TasklistNavigable = true;
		CalendarNavigable = true;

		_navigation = navigation;
	}

	public override void Dispose()
	{
		// nothing to destruct
	}


	// --> 4: PUBLIC METHODS {b}
	[RelayCommand]
	public void Navigate(PageName page)
	{
		TasklistNavigable = true;
		CalendarNavigable = true;
		
		switch (page)
		{
			case PageName.TASKLIST:
				TasklistNavigable = false;
				_navigation.NavigateToPage(PageName.TASKLIST);
				break;
			case PageName.CALENDAR:
				CalendarNavigable = false;
				_navigation.NavigateToPage(PageName.CALENDAR);
				break;
		}
	}


	// --> 5: PRIVATE METHODS {v}
	//
	

}
