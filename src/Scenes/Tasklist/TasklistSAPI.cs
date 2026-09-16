using System;
using Avalonia.Input;
using Violet.Services;

namespace Violet.Scenes;

public class TasklistSAPI : SAPIBase
{
	private TasklistScene _scene;
	
	// --> CONSTRUCTOR {r}
	public TasklistSAPI(TasklistScene scene)
	{
		_scene = scene;
	}


	// --> SAPI METHODS {b}
	public void RegisterKeybind(KeyGesture keyGesture, Action callback)
	{
		_scene.SubscribeToKeybind(keyGesture, callback);
	}

	public void UnregisterKeybind(KeyGesture keyGesture, Action callback)
	{
		_scene.UnsubscribeToKeybind(keyGesture, callback);
	}
}