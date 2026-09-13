using System;
using System.Globalization;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Violet.Scenes;
using Violet.ViewModels;
using Violet.Views;

namespace Violet;

public enum PageName
{
	TASKLIST,
	CALENDAR,
}

/* {#fff}
{ CLASS DESCRIPTION }
	Presenter is a non-Backend-owned service that is responsible for performing
	Scene changes safely. Direct Scene change via MainViewModel.DisplayVmAsScene() is
	not recommended.
*/


public class Presenter
{	
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private const PageName InitialPage = PageName.TASKLIST;
	
	private readonly Backend _backend;

	// presenter directly owns both main window and main vm; main window
	// DOES NOT own main vm: they are synced together by the presenter
	private MainWindow? _mainWindow;
	private MainViewModel? _mainVM;
	

	// --> 2: PROPERTIES {y}
	//


	// --> 3: CONSTRUCTOR, DEPENDENCY INJECTIONS {g}
	public Presenter(Backend backend)
	{
		_backend = backend;
	}

	// called by App after framework init, to start presentation
	public void GenerateMainWindow(IClassicDesktopStyleApplicationLifetime desktop)
	{
		// initialize a MainWindow and a MainVM
		_mainWindow = new MainWindow();
		_mainVM = new MainViewModel(this);

		// set MainWindow as the actual window of the app
		desktop.MainWindow = _mainWindow;

		// set MainVM as the VM of MainWindow
		_mainWindow.DataContext = _mainVM;

		// switch to the intended landing page
		NavigateToPage(InitialPage);
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
				var tlScene = new TasklistScene(_backend.ReadOnlyData, _backend.TaskService);
				var tlViewmodel = tlScene.SceneVM;
				ChangeCurrentSceneVM(tlViewmodel);
	
				break;
		
			case PageName.CALENDAR:
				var clScene = new CalendarScene(_backend.ReadOnlyData);
				var clViewmodel = clScene.SceneVM;
				ChangeCurrentSceneVM(clViewmodel);

				break;
		}
	}


	// --> 5: INTERNAL METHODS {v}
	// largely an implementation detail of NavigateToPage()
	// switches the Scene VM currently being displayed in the main window
	private void ChangeCurrentSceneVM(ViewModelBase sceneModel)
	{
		if (_mainWindow == null) return;
		
		// either create a new MainVM (if null) or edit CurrentPage
		var mvm = _mainWindow.DataContext as MainViewModel;
		if (mvm == null)
		{
			// create a new MVM and attach it to MainWindow
			_mainWindow.DataContext = new MainViewModel(sceneModel, this);
		}
		else
		{
			// interact with the existing MVM
			mvm.DisplaySceneVM(sceneModel);
		}
	}
}