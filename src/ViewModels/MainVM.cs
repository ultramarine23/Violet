using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Violet.Services;
using Violet.Views;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	MainViewModel is the VM connecting the MainWindow 
	and MainWindow.
*/


public partial class MainViewModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private Presenter _presenter;
	

	// --> 2: PROPERTIES {y}
	public SidebarViewModel SidebarVM { get; private set; }
	
	[ObservableProperty]
	private ViewModelBase? _currentPage;


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public MainViewModel(Presenter presenter)
	{
		_presenter = presenter;
		SidebarVM = new SidebarViewModel(_presenter);
	}

	public MainViewModel(ViewModelBase pageVM, Presenter presenter)
	{
		_presenter = presenter;
		CurrentPage = pageVM;
		SidebarVM = new SidebarViewModel(_presenter);
	}

	public override void Dispose()
	{
		SidebarVM.Dispose();
		if (CurrentPage != null) CurrentPage.Dispose();
	}


	// --> 4: PUBLIC METHODS {b}
	public void DisplaySceneModel(ViewModelBase sceneModel)
	{
		// no need to do anything on top of this; the ObservableProperty
		// will automatically update the MainView.
		CurrentPage = sceneModel;
	}


	// --> 5: PRIVATE METHODS {v}
	//
	
	
}
