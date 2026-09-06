using Violet.Pages;

namespace Violet.ViewModels;

public class TasksViewModel : ViewModelBase
{
	private readonly TasksPage _tasksPage;

	public TasksViewModel(TasksPage tasksPage)
	{
		_tasksPage = tasksPage;
	}
}
