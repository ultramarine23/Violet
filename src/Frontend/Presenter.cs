using System;
using System.Globalization;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Input;
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
	// --> 1: INTERNALS {r}
	private const PageName InitialPage = PageName.TASKLIST;
	
	private readonly Backend _backend;
	private ViewRegistry? _viewRegistry; // largely only here to be passed to focus controller

	// presenter directly owns both main window and main vm; main window
	// DOES NOT own main vm: they are synced together by the presenter
	private MainWindow? _mainWindow;
	private MainViewModel? _mainVM;

	private KeybindManager _keybindManager;
	private FocusController? _focusController;

	// API versions of the above, to be injected into scenes and such
	private KeybindAPI _keybindAPI;
	private FocusAPI? _focusAPI;
	

	// --> 2: PROPERTIES {y}
	//


	// --> 3: CONSTRUCTOR, DEPENDENCY INJECTIONS {g}
	public Presenter(Backend backend, ViewRegistry viewRegistry)
	{
		_keybindManager = new KeybindManager();
		_keybindAPI = new KeybindAPI(_keybindManager);

		_backend = backend;
		_viewRegistry = viewRegistry;
	}

	// called by App after framework init, to start presentation
	public void GenerateMainWindow(IClassicDesktopStyleApplicationLifetime desktop)
	{
		// initialize a MainWindow and a MainVM
		_mainWindow = new MainWindow(_keybindManager);
		_mainVM = new MainViewModel(this);

		// set MainWindow as the actual window of the app
		desktop.MainWindow = _mainWindow;

		// set MainVM as the VM of MainWindow
		_mainWindow.DataContext = _mainVM;

		// initialize MainWindow dependents
		_focusController = new FocusController(_mainWindow.FocusManager, _viewRegistry);
		_focusAPI = new FocusAPI(_focusController);

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
				var tlScene = new TasklistScene(
					_backend.ReadOnlyData, 
					_backend.TaskService, 
					_keybindAPI,
					_focusAPI!
					);
				
				var tlViewmodel = tlScene.SceneVM;
				ChangeCurrentSceneVM(tlViewmodel);
	
				break;
		
			case PageName.CALENDAR:
				var clScene = new CalendarScene(
					_backend.ReadOnlyData, 
					_keybindAPI,
					_focusAPI!
				);

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