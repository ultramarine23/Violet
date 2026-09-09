using System.Collections.ObjectModel;
using System.Linq;
using Violet.Models;
using Violet.Pages;

namespace Violet.ViewModels;

public partial class TasklistViewModel : ViewModelBase
{
	private readonly TasklistComposer _tasksPage;
	private readonly AppData _appData;
	
	public ObservableCollection<TaskViewModel> TaskViewModels { get; }


	public TasklistViewModel(TasklistComposer tasksPage)
	{
		_tasksPage = tasksPage;
		_appData = tasksPage.appData;
		
		TaskViewModels = new ObservableCollection<TaskViewModel>(
            _appData.Tasks.Select(x => new TaskViewModel(x))
        );
	}
}
