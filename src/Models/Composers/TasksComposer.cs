using System;
using System.Collections.Generic;
using Violet.Models;

namespace Violet.Pages;

public class TasksComposer : ComposerBase
{
	public List<Task> tasks;


	public TasksComposer()
	{
		tasks = [new Task("boop", DateTime.Now, TimeSpan.FromHours(5))];
	}


	public void DeleteTask(Task task)
	{
		tasks.Remove(task);
	}
}