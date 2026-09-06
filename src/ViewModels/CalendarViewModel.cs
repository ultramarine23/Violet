using Violet.Pages;

namespace Violet.ViewModels;

public partial class CalendarViewModel : ViewModelBase
{
	private readonly CalendarComposer _tasksPage;

	public CalendarViewModel(CalendarComposer tasksPage)
	{
		_tasksPage = tasksPage;
	}
}
