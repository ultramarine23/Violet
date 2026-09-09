using System.Collections.Generic;

namespace Violet.Models;

public class AppData
{
	public List<Task> tasks;
	
	public AppData()
	{
		tasks = new List<Task>();
	}
}