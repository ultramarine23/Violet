using System;
using System.Globalization;
using Violet.Pages;
using Violet.ViewModels;
using Violet.Views;

namespace Violet.Services;

public class NavigationService
{
	public enum Page
	{
		TASKLIST,
		CALENDAR,
	}
	
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

	public void NavigateToPage(Page page)
	{
		if (_mainWindow == null)
		{
			// push an error
			return;
		}
		
		switch (page)
		{
			case Page.TASKLIST:
				Console.WriteLine("we successfully got here!");
				var tlComposer = new TasklistComposer();
				var tlViewmodel = new TasklistViewModel(tlComposer);

				_backend.CurrentPage = tlComposer;
				_mainWindow.DataContext = new MainViewModel(tlViewmodel);
				break;
			case Page.CALENDAR:
				var clComposer = new CalendarComposer();
				var clViewmodel = new CalendarViewModel(clComposer);

				_backend.CurrentPage = clComposer;
				_mainWindow.DataContext = new MainViewModel(clViewmodel);
				break;
		}

	}
}