using System;
using Avalonia.Controls;
using Avalonia.Input;
using Violet.ViewModels;

namespace Violet.Views;

public partial class TaskView : UserControl, IFocusable
{
    public Control FocusDestination { get; }

    public TaskView()
    {
        InitializeComponent();
        FocusDestination = Description;
    }
}