using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Violet.Pages;
using Violet.Services;
using Violet.ViewModels;
using Violet.Views;

namespace Violet;

public partial class App : Application
{
    public Backend Backend { get; private set; }
    public NavigationService Navigation { get; private set; }
    
    public App()
    {
        Backend = new Backend();
        Navigation = new NavigationService(Backend);
    }


    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {            
            var mainWindow = new MainWindow();
            Navigation.InjectMainWindow(mainWindow);

            desktop.MainWindow = mainWindow;
            // desktop.MainWindow.DataContext 
            // {
            //     DataContext = new TasklistViewModel(new TasklistComposer())
            // };
        }

        Navigation.NavigateToPage(NavigationService.Page.TASKLIST);

        base.OnFrameworkInitializationCompleted();
    }
}