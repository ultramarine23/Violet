using Violet.Pages;

namespace Violet.ViewModels;

public class CalendarViewModel : ViewModelBase
{
	private readonly TasksPage _tasksPage;

	public CalendarViewModel(TasksPage tasksPage)
	{
		_tasksPage = tasksPage;
	}
}
