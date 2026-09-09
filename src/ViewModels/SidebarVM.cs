using System;
using System.Collections.Generic;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Pages;

namespace Violet.ViewModels;

public partial class SidebarViewModel : ViewModelBase
{
	[ObservableProperty]
	private bool _tasklistNavigable;

	[ObservableProperty]
	private bool _calendarNavigable;


	public SidebarViewModel()
	{
		TasklistNavigable = true;
		CalendarNavigable = true;
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
				break;
			case PageName.CALENDAR:
				CalendarNavigable = false;
				break;
		}
	}
}
