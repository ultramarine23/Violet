using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Services;

namespace Violet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private Backend _backend;
	private NavigationService _navigation;
	
	public SidebarViewModel SidebarVM { get; private set; }

	// fields
	[ObservableProperty]
	private object? _currentPage;

	public MainViewModel(Backend backend, NavigationService navigation)
	{
		_backend = backend;
		_navigation = navigation;
		SidebarVM = new SidebarViewModel(_navigation);
	}

	// constructor
	public MainViewModel(ViewModelBase pageVM, Backend backend, NavigationService navigation)
	{
		_backend = backend;
		_navigation = navigation;
		CurrentPage = pageVM;
		SidebarVM = new SidebarViewModel(_navigation);
	}

}
