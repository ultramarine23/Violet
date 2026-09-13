using System;
using Avalonia.Input;
using Violet.Services;

namespace Violet.Scenes;

public class CalendarSAPI : SAPIBase
{
	private CalendarScene _scene;
	
	// --> CONSTRUCTOR {r}
	public CalendarSAPI(CalendarScene scene)
	{
		_scene = scene;
	}


	// --> SAPI METHODS {b}
	public void RegisterKeybind(KeyBinding keyBinding, Action callback)
	{
		_scene.SubscribeToKeybind(keyBinding, callback);
	}
}