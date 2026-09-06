using System;
using System.Collections.Generic;
using Violet.Models;

namespace Violet.Pages;

public class TasklistComposer : ComposerBase
{
	public List<Task> tasks;


	public TasklistComposer()
	{
		tasks = [new Task("boop", DateTime.Now, TimeSpan.FromHours(5))];
	}


	public void DeleteTask(Task task)
	{
		tasks.Remove(task);
	}
}