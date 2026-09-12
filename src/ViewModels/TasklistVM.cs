using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Models;
using Violet.Scenes;
using Violet.Services;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistSceneModel is the VM connecting the TasklistComposer 
	and TasklistScene.
*/


public partial class TasklistSceneModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly TasklistComposer _tasklistPage;
	private readonly AppDataReadOnly _appData;
	private readonly TaskService _taskService;
	

	// --> 2: PROPERTIES {y}
	public ObservableCollection<TaskViewModel> TaskViewModels { get; }

	[ObservableProperty]
	private TaskAdderViewModel _taskAdderVM;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistSceneModel(TasklistComposer tasksPage, TaskService taskService)
	{
		_tasklistPage = tasksPage;
		_appData = tasksPage.appData;
		_taskService = taskService;

		// initialize the Task VM list
		TaskViewModels = new ObservableCollection<TaskViewModel>();
		TaskAdderVM = new TaskAdderViewModel(_taskService);
		
		foreach (Task t in _appData.Tasks)
		{
			TaskViewModels.Add(new TaskViewModel(t));
		}

		// hook up the built-in CollectionChange notif to the syncing method
		// this syncs the Task collection to the TaskViewModel collection
		if (_appData.Tasks is INotifyCollectionChanged notif)
		{
			notif.CollectionChanged += SyncTaskVMs;
		}
	}

	public override void Dispose()
	{
		// unsubscribe from notification system before being freed
		if (_appData.Tasks is INotifyCollectionChanged notif)
		{
			notif.CollectionChanged -= SyncTaskVMs;
		}
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	private void SyncTaskVMs(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (Task item in e.NewItems!)
				{
					TaskViewModels.Add(new TaskViewModel(item));
				}
                break;

            case NotifyCollectionChangedAction.Remove:
				var uuidsForDeletion = new HashSet<Guid>();
				foreach (Task item in e.OldItems!)
				{
					uuidsForDeletion.Add(item.Uuid);
				}

				var deletions = TaskViewModels.Where((vm) => uuidsForDeletion.Contains(vm.Uuid));
                foreach (TaskViewModel vm in deletions)
				{
					TaskViewModels.Remove(vm);
				}
                break;

            case NotifyCollectionChangedAction.Replace:
                // handle replacement
                break;

            case NotifyCollectionChangedAction.Reset:
                // handle reset
                break;
		}
	}


}
