using System;
using System.Collections.Generic;
using Avalonia.Input;


public class KeybindManager
{
    private readonly Dictionary<KeyGesture, Action> _bindings = new();

    public void Register(KeyGesture gesture, Action action)
    {
        _bindings[gesture] = action;
    }

	public void Unregister(KeyGesture gesture, Action action)
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