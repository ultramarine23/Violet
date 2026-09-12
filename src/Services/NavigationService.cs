using System;
using System.Globalization;
using Avalonia.Data;
using Violet.Pages;
using Violet.ViewModels;
using Violet.Views;

namespace Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	NavigationService is a non-Backend-owned service that is responsible for performing
	Scene changes safely. Direct Scene change via MainViewModel.DisplayVmAsScene() is
	not recommended.
*/


public class NavigationService
{	
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly Backend _backend;
	private MainWindow? _mainWindow;
	

	// --> 2: PROPERTIES {y}
	//


	// --> 3: CONSTRUCTOR, DEPENDENCY INJECTIONS {g}
	public NavigationService(Backend backend)
	{
		_backend = backend;
		_mainWindow = null;
	}

	public void InjectMainWindow(MainWindow mainWindow)
	{
		_mainWindow = mainWindow;
	}


	// --> 4: MAIN API METHODS {b}
	public void NavigateToPage(PageName page)
	{
		if (_mainWindow == null)
		{
			Console.Error.WriteLine("No main window found! (Possibly not injected yet)");
			return;
		}

		switch (page)
		{
			case PageName.TASKLIST:
				var tlComposer = new TasklistComposer(_backend.ReadOnlyData, _backend.TaskService);
				var tlViewmodel = new TasklistSceneModel(tlComposer);

				_backend.CurrentPage = tlComposer;
				ChangeCurrentComposerVM(tlViewmodel);
	
				break;
		
			case PageName.CALENDAR:
				var clComposer = new CalendarComposer(_backend.ReadOnlyData);
				var clViewmodel = new CalendarSceneModel(clComposer);

				_backend.CurrentPage = clComposer;
				ChangeCurrentComposerVM(clViewmodel);

				break;
		}
	}


	// --> 5: INTERNAL METHODS {v}
	// largely an implementation detail of NavigateToPage()
	// switches the Composer VM currently being displayed in the main window
	private void ChangeCurrentComposerVM(ViewModelBase composer)
	{
		if (_mainWindow == null) return;
		
		// either create a new MainVM (if null) or edit CurrentPage
		var mvm = _mainWindow.DataContext as MainViewModel;
		if (mvm == null)
		{
			_mainWindow.DataContext = new MainViewModel(composer, _backend, this);
		}
		else
		{
			mvm.DisplayVmAsScene(composer);
		}
	}
}