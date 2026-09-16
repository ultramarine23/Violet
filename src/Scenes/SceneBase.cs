using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
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
	protected KeybindManager _keybindManager;


	protected SceneBase(KeybindManager keybindManager)
	{
		_keybindManager = keybindManager;
	}

	
	public void SubscribeToKeybind(KeyGesture keyGesture, Action callback)
	{
		_keybindManager.Register(keyGesture, callback);		
	}

	public void UnsubscribeToKeybind(KeyGesture keyGesture, Action callback)
	{
		_keybindManager.Unregister(keyGesture, callback);
	}
}

