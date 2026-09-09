using Violet.Models;

namespace Violet.Services;

public class TaskService
{
	private AppData _appData;
	
	public TaskService(AppData appData)
	{
		_appData = appData;
	}


	public void AddTask(Task task)
	{
		_appData.Tasks.Add(task);
	}
}