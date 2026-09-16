using Avalonia.Controls;
using Avalonia.Input;

namespace Violet.Views;

public partial class MainWindow : Window
{
    private readonly KeybindManager _keybindManager;
    
    public MainWindow(KeybindManager keybindManager)
    {
        InitializeComponent();

        _keybindManager = keybindManager;

        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        _keybindManager.HandleKeyDown(e.Key, e.KeyModifiers);
    }
}