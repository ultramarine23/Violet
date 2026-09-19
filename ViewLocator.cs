using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Violet.ViewModels;

namespace Violet;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
public class ViewLocator : IDataTemplate
{
    // this is ugly, but ViewRegistry is injected through App
    // technically ViewLocator is the DataContext ("VM") of App so...
    // skill diff between me, lv 1 noobgrammer vs. lv 99 lord of OOP
    private ViewRegistry? _viewRegistry;


    public ViewLocator()
    {
        // this shouldnt happen TT
        // well, it should, but it should get overwritten
        _viewRegistry = null;
    }


    public ViewLocator(ViewRegistry viewRegistry)
    {
        _viewRegistry = viewRegistry;
    }


    public Control? Build(object? param)
    {
        if (param is null)
            return null;
        
        // ViewLocator tries to find the corresponding View {white, 3}
        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        if (name.EndsWith("VM")) name = name[..^1] + "V";
        var type = Type.GetType(name);

        if (type != null)
        {
            // fancy way to do "new Type()"
            var viewInstance = (Control)Activator.CreateInstance(type)!;
            
            if ((param is ViewModelBase vm) && _viewRegistry != null)
            {
                _viewRegistry.Register(vm, viewInstance);
            }
            else 
            {
                return new TextBlock { Text = "ViewModel Not Found: " + name };
            }

            return viewInstance;
        }
        
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
