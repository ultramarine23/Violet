using System;
using System.Collections.Generic;
using Violet.Models;

namespace Violet;

public class TaskNotificationSystem
{
	private readonly List<Action<Task>> _callbacks;
	

	public TaskNotificationSystem()
	{
		_callbacks = new List<Action<Task>>();
	}

	public void Subscribe(Action<Task> callback)
	{
		_callbacks.Add(callback);
	}

	public void Unsubscribe(Action<Task> callback)
	{
		_callbacks.Remove(callback);
	}
}