using System;
using System.Collections.Generic;
using Avalonia.Input;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	A Presenter-level manager that handles keybinds. 
	
	Constructed by Presenter and is passed into MainWindow, 
	where its HandleKeyDown is bound to actual key presses. 

	Passed as a dependency onto Scenes, then onto its VMs.
*/


public class KeybindManager
{
    private readonly Dictionary<KeyGesture, Action> _bindings = new();

    public void Register(KeyGesture gesture, Action action)
    {
        _bindings[gesture] = action;
    }

	public void Unregister(KeyGesture gesture)
	{
		if (!_bindings.ContainsKey(gesture))
		{
			return;
		}
		
		_bindings.Remove(gesture);
	}

    public void HandleKeyDown(Key key, KeyModifiers modifiers)
    {
        var gesture = new KeyGesture(key, modifiers);

        if (_bindings.TryGetValue(gesture, out var action)) 
		{
			action();
		}
    }
}