using Violet.Pages;

namespace Violet.ViewModels;

public partial class CalendarViewModel : ViewModelBase
{
	private readonly TasksComposer _tasksPage;

	public CalendarViewModel(TasksComposer tasksPage)
	{
		_tasksPage = tasksPage;
	}
}
