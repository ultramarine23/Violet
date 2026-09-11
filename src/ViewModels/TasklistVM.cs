using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.Input;
using Violet.Models;
using Violet.Pages;
using Violet.Services;
using Violet.Views;

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

		// initialize the Task VM list
		TaskViewModels = new ObservableCollection<TaskViewModel>();
		
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


	public void SyncTaskVMs(object? sender, NotifyCollectionChangedEventArgs e)
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
					uuidsForDeletion.Add(item.uuid);
				}

				var deletions = TaskViewModels.Where((vm) => uuidsForDeletion.Contains(vm.uuid));
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


	[RelayCommand]
	public void AddTask()
	{
		_tasklistPage.AddTask();
	}
}
