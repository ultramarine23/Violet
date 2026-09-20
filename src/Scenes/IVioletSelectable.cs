using System;
using System.Collections.Generic;
using Avalonia.Input;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	Interface implemented by classes that can be "selected".
*/


public interface IVioletSelectable
{
	public IVioletSelectable? LeftNeighbor { get; set; }
	public IVioletSelectable? RightNeighbor { get; set; }
	public IVioletSelectable? BottomNeighbor { get; set; }
	public IVioletSelectable? TopNeighbor { get; set; }

	// a list of keybinds that are registered upon being selected
	public Dictionary<KeyGesture, Action> SelectedKeybinds { get; set; }
}