using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public SidebarViewModel SidebarVM { get; private set; }
	
	// fields
	[ObservableProperty]
	private object? _currentPage;

	public MainViewModel()
	{
		SidebarVM = new SidebarViewModel();
	}

	// constructor
	public MainViewModel(ViewModelBase pageVM)
	{
		CurrentPage = pageVM;
		SidebarVM = new SidebarViewModel();
	}

}
