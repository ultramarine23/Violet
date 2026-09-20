using System;
using Avalonia.Input;

namespace Violet;

public class KeybindAPI
{
	private KeybindManager _manager;

	public KeybindAPI(KeybindManager manager)
	{
		_manager = manager;
	}

	// API-accessible methods {r}
	public void Register(KeyGesture gesture, Action action)
    {
       _manager.Register(gesture, action);
    }

	// the action overload is only there to make certain calls more
	// readable (the reader also sees the action being unregistered)
	public void Unregister(KeyGesture gesture, Action action)
	{
		_manager.Unregister(gesture);
	}

	public void Unregister(KeyGesture gesture)
	{
		_manager.Unregister(gesture);
	}
}