using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Violet.ViewModels;

public abstract class ViewModelBase : ObservableObject, IDisposable
{
	public abstract void Dispose();
}
