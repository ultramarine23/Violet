using System.Collections.Generic;
using Avalonia.Controls;

namespace Violet.Models;

public class TasksPage
{
	public List<Task> tasks;


	public TasksPage()
	{
		tasks = [];
	}
}