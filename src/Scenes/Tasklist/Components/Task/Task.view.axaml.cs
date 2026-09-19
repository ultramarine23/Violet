using System;
using Avalonia.Controls;
using Violet.ViewModels;

namespace Violet.Views;

public partial class TaskView : UserControl
{
    public TaskView()
    {
    	InitializeComponent();
        
        DataContextChanged += SyncToDataContext;
    }


    public void SyncToDataContext(object? sender, EventArgs e)
    {
        
        if (DataContext is TaskViewModel vm)
        {
            vm?.EditStateEnded += LoseFocus;
        } 
        else
        {
            return;
        }
    }


    public void LoseFocus()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        topLevel.FocusManager.Focus(topLevel.FocusManager.FindNextElement(Avalonia.Input.NavigationDirection.Down));
    }
}