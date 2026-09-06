using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Models;

namespace Violet.ViewModels;

public abstract class TasksPageViewModel : ObservableObject
{
	private readonly TasksPage _tasksPage;

	public TasksPageViewModel(TasksPage tasksPage)
	{
		_tasksPage = tasksPage;
	}
}
