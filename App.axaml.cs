using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Violet.ViewModels;
using Violet.Views;

namespace Violet;

public partial class App : Application
{
    public Backend Backend { get; private set; }
    
    public App()
    {
        Backend = new Backend();
    }


    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            TasksViewModel tasksVM = new TasksViewModel(Backend.Tasks);
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(tasksVM),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}