using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Input;
using Violet;
using Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	SceneBase is the base class for all scenes. A scene is the backend
	representation of an entire “page”; it serves as a through-point that links the 
	near-backend (services system) to the near-frontend (viewmodels).
*/


public abstract class SceneBase
{
	protected Dictionary<KeyBinding, List<Action>> _keyBindings;


	protected SceneBase()
	{
		_keyBindings = new Dictionary<KeyBinding, List<Action>>();
	}

	
	public void SubscribeToKeybind(KeyBinding keyBinding, Action callback)
	{
		if (!_keyBindings.ContainsKey(keyBinding))
		{
			_keyBindings[keyBinding] = new List<Action>();
		}
		
		var actionList = _keyBindings[keyBinding];
		actionList.Add(callback);
	}

	public void UnsubscribeToKeybind(KeyBinding keyBinding, Action callback)
	{
		if (!_keyBindings.ContainsKey(keyBinding))
		{
			return;
		}
		
		var actionList = _keyBindings[keyBinding];
		actionList.Remove(callback);
	}
}

