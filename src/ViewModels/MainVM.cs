using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Services;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	MainViewModel is the VM connecting the MainWindow 
	and MainWindow.
*/


public partial class MainViewModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private Backend _backend;
	private NavigationService _navigation;
	

	// --> 2: PROPERTIES {y}
	public SidebarViewModel SidebarVM { get; private set; }
	
	[ObservableProperty]
	private ViewModelBase? _currentPage;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public MainViewModel(Backend backend, NavigationService navigation)
	{
		_backend = backend;
		_navigation = navigation;
		SidebarVM = new SidebarViewModel(_navigation);
	}

	public MainViewModel(ViewModelBase pageVM, Backend backend, NavigationService navigation)
	{
		_backend = backend;
		_navigation = navigation;
		CurrentPage = pageVM;
		SidebarVM = new SidebarViewModel(_navigation);
	}

	public override void Dispose()
	{
		SidebarVM.Dispose();
		if (CurrentPage != null) CurrentPage.Dispose();
	}


	// --> 4: PUBLIC METHODS {b}
	public void DisplayVmAsScene(ViewModelBase composerVM)
	{
		// no need to do anything on top of this; the ObservableProperty
		// will automatically update the MainView.
		CurrentPage = composerVM;
	}


	// --> 5: PRIVATE METHODS {v}
	//
	
	
}
