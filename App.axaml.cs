using System;
using System.Linq;
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


public partial class App : Application
{    
    // The Three Holy Relics: the major components of App
    private readonly Backend _backend;
    private readonly Presenter _presenter;
    private readonly ViewRegistry _viewRegistry;
    

    // --> CONSTRUCTOR {r}
    public App()
    {
        _viewRegistry = new ViewRegistry();

        _backend = new Backend();
        _presenter = new Presenter(_backend, _viewRegistry);
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
        // explicitly add the ViewLocator as a DataTemplate
        // (instead of relying on some under-the-hood woo woo)
        DataTemplates.RemoveAt(0);
        DataTemplates.Add(new ViewLocator(_viewRegistry));

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {            
            _presenter.GenerateMainWindow(desktop);
        }

        base.OnFrameworkInitializationCompleted();
    }
}