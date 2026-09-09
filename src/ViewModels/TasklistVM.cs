using System.Collections.ObjectModel;
using System.Linq;
using Violet.Pages;

namespace Violet.ViewModels;

public partial class TasklistViewModel : ViewModelBase
{
	private readonly TasklistComposer _tasksPage;
	
	public ObservableCollection<TaskViewModel> TaskList { get; }


	public TasklistViewModel(TasklistComposer tasksPage)
	{
		_tasksPage = tasksPage;
		
		TaskList = new ObservableCollection<TaskViewModel>(
            _tasksPage.tasks.Select(x => new TaskViewModel(x))
        );
	}
}
