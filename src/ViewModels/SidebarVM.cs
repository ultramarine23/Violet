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
	private readonly NavigationService _navigation;

	
	[ObservableProperty]
	private bool _tasklistNavigable;

	[ObservableProperty]
	private bool _calendarNavigable;


	public SidebarViewModel(NavigationService navigation)
	{
		TasklistNavigable = true;
		CalendarNavigable = true;

		_navigation = navigation;
	}


	[RelayCommand]
	private void Navigate(PageName page)
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
}
