using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Pages;

namespace Violet.ViewModels;

public partial class SidebarViewModel : ViewModelBase
{
	[ObservableProperty]
	private bool _tasklistNavigable;

	public SidebarViewModel()
	{
		TasklistNavigable = true;
	}
}
