using System;
using Avalonia.Input;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	A Scene-level manager that handles selection and is the authoritative
	source for determining the selection status of a control. 
	
	Objects that are selected =/= objects that are focused. Objects that
	are selected have custom behavior, and special keybinds.

	Passed as a dependency onto scene VMs.
*/


public class SelectionManager
{
	private KeybindAPI _keybindAPI;
	
	public IVioletSelectable? SelectedObject { get; private set; }

	public event Action? SelectionChanged;
	
	public SelectionManager(KeybindAPI keybindAPI)
	{
		_keybindAPI = keybindAPI;
		SelectedObject = null;
	}

	public void GrabSelection(IVioletSelectable target)
	{
		SelectedObject = target;
		SelectionChanged?.Invoke();
	}

	public void ReleaseSelection()
	{
		if (SelectedObject == null)
		{
			return;
		}
		
		var keybinds = SelectedObject.SelectedKeybinds;
		foreach (KeyGesture gesture in keybinds.Keys)
		{
			_keybindAPI.Unregister(gesture, keybinds[gesture]);
		}
		
		SelectedObject = null;
		SelectionChanged?.Invoke();
	}
}