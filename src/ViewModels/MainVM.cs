using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // fields
	[ObservableProperty]
	private object? _currentPage;


	// constructor
	public MainViewModel(ViewModelBase pageVM)
	{
		CurrentPage = pageVM;
	}

}
