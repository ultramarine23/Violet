using System;
using System.Data.Common;
using Avalonia.Input;
using Violet.ViewModels;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	A Presenter-level manager that wraps the FocusManager. 
	
	Unlike KeybindManager, FocusManager is constructed later on, after the 
	creation of the MainWindow, since it operates with the window's FocusManager. 

	Passed as a dependency onto Scenes, then onto its VMs.
*/


public class FocusController
{
	private IFocusManager _focusManager;
	private ViewRegistry _viewRegistry;

	public FocusController(IFocusManager focusManager, ViewRegistry viewRegistry)
	{
		_focusManager = focusManager;
		_viewRegistry = viewRegistry;
	}

	public void GrabFocus(ViewModelBase vm)
	{
		IInputElement? targetControl = _viewRegistry.Lookup(vm);

		// bro why is c# static typing so annoying pmo sia
		if ((targetControl != null) && (targetControl is IFocusCandidate focusable))
		{			
			focusable.FocusDestination.Focus();
		}
		else
		{
			Console.WriteLine("Attempt to grab focus of unregistered/nonexistent view");
		}
	}

	public void ReleaseFocus()
	{
		_focusManager.Focus(null);
	}
}