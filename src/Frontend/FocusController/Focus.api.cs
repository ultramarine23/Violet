using System;
using Avalonia.Input;
using Violet.ViewModels;

namespace Violet;

public class FocusAPI
{
	private FocusController _manager;

	public FocusAPI(FocusController manager)
	{
		_manager = manager;
	}

	// API-accessible methods {r}
	public void GrabFocus(ViewModelBase vm)
	{
		_manager.GrabFocus(vm);
	}

	public void ReleaseFocus()
	{
		_manager.ReleaseFocus();
	}
}