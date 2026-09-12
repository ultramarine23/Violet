using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Violet.Services;
using Violet.Views;

namespace Violet;


/* {#fff}
{ CLASS DESCRIPTION }
	App is the root of the entire program, and the owner of
*/


public enum PageName
{
	TASKLIST,
	CALENDAR,
}


public partial class App : Application
{
    private const PageName InitialPage = PageName.TASKLIST;
    
    // The Three Holy Relics: the major components of App
    private readonly Backend _backend;
    private readonly NavigationService _navigation;
    private MainWindow? _mainWindow;
    

    // --> CONSTRUCTOR {r}
    public App()
    {
        _backend = new Backend();
        _navigation = new NavigationService(_backend);
        _mainWindow = null;
    }


    // --> INITIALIZER {y}
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }


    // --> MAIN WINDOW LOADER {b}
    // this is run once at the start of the program, after initialization
    public override void OnFrameworkInitializationCompleted()
    {        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {            
            _mainWindow = new MainWindow();
            desktop.MainWindow = _mainWindow;
            _navigation.InjectMainWindow(_mainWindow);
        }

        _navigation.NavigateToPage(InitialPage);

        base.OnFrameworkInitializationCompleted();
    }
}