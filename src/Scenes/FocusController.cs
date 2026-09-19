using System;
using System.Data.Common;
using Avalonia.Input;
using Violet.ViewModels;

namespace Violet;

public class FocusController
{
	private IFocusManager _focusManager;
	private ViewRegistry _viewRegistry;

	public event Action? SelectionChanged;
	
	public FocusController(IFocusManager focusManager, ViewRegistry viewRegistry)
	{
		_focusManager = focusManager;
		_viewRegistry = viewRegistry;
	}

	public void GrabFocus(ViewModelBase vm)
	{
		IInputElement? targetControl = _viewRegistry.Lookup(vm);

		if ((targetControl != null) && (targetControl is IFocusable focusable))
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