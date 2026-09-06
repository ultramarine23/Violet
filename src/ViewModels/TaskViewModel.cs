using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Models;

namespace Violet.ViewModels;

public partial class TaskViewModel : ViewModelBase
{
	[ObservableProperty]
	private string _description;

	public TaskViewModel(Task task)
	{
		Description = task.description;
	}
}
