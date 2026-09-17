using System;
using Violet.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Violet.Services;
using System.Collections.ObjectModel;
using Violet.Scenes;
using System.Collections.Specialized;
using System.Linq;

namespace Violet.ViewModels;

public partial class KanbanColumnViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly TasklistDependencies _dependencies;


	// --> 2: PROPERTIES {y}
	[ObservableProperty]
	private string _columnName;

	public ObservableCollection<TaskViewModel> TaskViewModels { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public KanbanColumnViewModel(TasklistDependencies dependencies, string colName)
	{
		_dependencies = dependencies;
		ColumnName = colName;

		TaskViewModels = new ObservableCollection<TaskViewModel>();
		foreach (Task t in dependencies.ReadOnlyData.Tasks)
		{
			TaskViewModels.Add(new TaskViewModel(dependencies, t));
		}

		// this syncs the Task collection to the TaskViewModel collection
		if (_dependencies.ReadOnlyData.Tasks is INotifyCollectionChanged notif)
		{
			notif.CollectionChanged += SyncTaskVMs;
		}
	}

	public override void Dispose()
	{
		// unsubscribe from notification system before being freed
		if (_dependencies.ReadOnlyData.Tasks is INotifyCollectionChanged notif)
		{
			notif.CollectionChanged -= SyncTaskVMs;
		}
	}


	// --> 4: RELAY COMMANDS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	private void SyncTaskVMs(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (Task item in e.NewItems!)
				{
					TaskViewModels.Add(new TaskViewModel(_dependencies, item));
				}
                break;

            case NotifyCollectionChangedAction.Remove:
                foreach (Task item in e.OldItems!)
				{
					var vm = TaskViewModels.First((x) => x.Uuid == item.Uuid);
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
