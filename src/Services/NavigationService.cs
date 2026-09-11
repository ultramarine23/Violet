using System;
using System.Globalization;
using Violet.Pages;
using Violet.ViewModels;
using Violet.Views;

namespace Violet.Services;

public class NavigationService
{	
	private readonly Backend _backend;
	private MainWindow? _mainWindow;
	
	public NavigationService(Backend backend)
	{
		_backend = backend;
		_mainWindow = null;
	}

	public void InjectMainWindow(MainWindow mainWindow)
	{
		_mainWindow = mainWindow;
	}

	public void NavigateToPage(PageName page)
	{
		if (_mainWindow == null)
		{
			// push an error
			return;
		}
		
		var mvm = _mainWindow.DataContext as MainViewModel;

		switch (page)
		{
			case PageName.TASKLIST:
				Console.WriteLine("we successfully got here!");
				var tlComposer = new TasklistComposer(_backend.ReadOnlyData, _backend.TaskService);
				var tlViewmodel = new TasklistViewModel(tlComposer);

				_backend.CurrentPage = tlComposer;

				// generate a new MainVM as DataContext if the current DataContext is null
				if (mvm == null)
				{
					_mainWindow.DataContext = new MainViewModel(tlViewmodel, _backend, this);
				}
				else
				{
					mvm.CurrentPage = tlViewmodel;
				}
	
				break;
				
			case PageName.CALENDAR:
				var clComposer = new CalendarComposer(_backend.ReadOnlyData);
				var clViewmodel = new CalendarViewModel(clComposer);

				_backend.CurrentPage = clComposer;

				// generate a new MainVM as DataContext if the current DataContext is null
				if (mvm == null)
				{
					_mainWindow.DataContext = new MainViewModel(clViewmodel, _backend, this);
				}
				else
				{
					mvm.CurrentPage = clViewmodel;
				}

				break;
		}
	}
}