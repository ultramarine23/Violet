using System;
using System.Collections.Generic;
using Violet.Models;

namespace Violet.Pages;

public class TasksPage : PageBase
{
	public List<Task> tasks;


	public TasksPage()
	{
		tasks = [new Task("boop", DateTime.Now, TimeSpan.FromHours(5))];
	}
}