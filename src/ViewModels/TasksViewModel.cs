using System.Collections.ObjectModel;
using System.Linq;
using Violet.Pages;

namespace Violet.ViewModels;

public partial class TasksViewModel : ViewModelBase
{
	private readonly TasksComposer _tasksPage;
	
	public ObservableCollection<TaskViewModel> TaskList { get; }


	public TasksViewModel(TasksComposer tasksPage)
	{
		_tasksPage = tasksPage;
		
		TaskList = new ObservableCollection<TaskViewModel>(
            _tasksPage.tasks.Select(x => new TaskViewModel(x))
        );
	}
}
