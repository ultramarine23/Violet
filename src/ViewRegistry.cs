using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Violet.ViewModels;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	A dictonary wrapper that keeps track of all ViewModel -> View mappings.

	Owned by the App, as one of the Three Holy Relics (with Backend & Presenter).
	Passed down into the Presenter -> FocusManager.
*/


public class ViewRegistry
{
	private Dictionary<ViewModelBase, Control> _allViews;
	
	public ViewRegistry()
	{
		_allViews = new();
	}


	public void Register(ViewModelBase vm, Control view)
	{
		_allViews[vm] = view;
	}

	public void Unregister(ViewModelBase vm)
	{
		_allViews.Remove(vm);
	}

	public Control? Lookup(ViewModelBase vm)
	{
		if (_allViews.TryGetValue(vm, out var resView) == true)
		{
			return resView;
		}
		else
		{
			return null;
		}
	}
}