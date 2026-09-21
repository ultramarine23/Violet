using System;
using System.Collections.Generic;
using Avalonia.Input;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	Interface implemented by classes that can be "selected".
*/


public interface ISelectCandidate
{
	public ISelectCandidate? LeftNeighbor { get; set; }
	public ISelectCandidate? RightNeighbor { get; set; }
	public ISelectCandidate? BottomNeighbor { get; set; }
	public ISelectCandidate? TopNeighbor { get; set; }

	// a list of keybinds that are registered upon being selected
	public Dictionary<KeyGesture, Action> SelectedKeybinds { get; set; }
}