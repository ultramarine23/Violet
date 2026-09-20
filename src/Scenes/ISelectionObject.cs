using System;
using System.Collections.Generic;
using Avalonia.Input;

namespace Violet;

public interface ISelectionObject
{
	public ISelectionObject? LeftNeighbor { get; set; }
	public ISelectionObject? RightNeighbor { get; set; }
	public ISelectionObject? BottomNeighbor { get; set; }
	public ISelectionObject? TopNeighbor { get; set; }

	// a list of keybinds that are registered upon being selected
	public Dictionary<KeyGesture, Action> SelectedKeybinds { get; set; }
}