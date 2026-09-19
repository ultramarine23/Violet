using Avalonia.Controls;

namespace Violet;

public interface IFocusable
{
	public Control FocusDestination { get; }
}