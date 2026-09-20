using Avalonia.Controls;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	An interface implemented by View objects that can be focused via
	the custom Focus system (ie. FocusController-FocusAPI operations)
*/


public interface IFocusable
{
	public Control FocusDestination { get; }
}