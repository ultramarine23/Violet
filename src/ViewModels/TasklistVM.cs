using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.Input;
using Violet.Models;
using Violet.Pages;
using Violet.Services;

namespace Violet.ViewModels;

public partial class TasklistViewModel : ViewModelBase
{
	private readonly TasklistComposer _tasklistPage;
	private readonly AppDataReadOnly _appData;
	
	public ObservableCollection<TaskViewModel> TaskViewModels { get; }


	public TasklistViewModel(TasklistComposer tasksPage)
	{
		_tasklistPage = tasksPage;
		_appData = tasksPage.appData;
		
		TaskViewModels = new ObservableCollection<TaskViewModel>(
            _appData.Tasks.Select(x => new TaskViewModel(x))
        );
		
	}


	[RelayCommand]
	public void AddTask()
	{
		_tasklistPage.AddTask();
	}
}
