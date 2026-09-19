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

	Constructed by Presenter upon navigating to a new scene.
*/


public abstract class SceneBase
{
	protected KeybindAPI _keybindAPI;
	protected FocusAPI _focusAPI;

	protected SelectionManager _selectionManager;
	protected SelectionAPI _selectionAPI;

	protected SceneBase(KeybindAPI keybindAPI, FocusAPI focusAPI)
	{
		_keybindAPI = keybindAPI;
		_focusAPI = focusAPI;
		_selectionManager = new SelectionManager(_keybindAPI);
		_selectionAPI = new SelectionAPI(_selectionManager);
	}

	
	public void SubscribeToKeybind(KeyGesture keyGesture, Action callback)
	{
		_keybindAPI.Register(keyGesture, callback);		
	}

	public void UnsubscribeToKeybind(KeyGesture keyGesture, Action callback)
	{
		_keybindAPI.Unregister(keyGesture, callback);
	}


}

