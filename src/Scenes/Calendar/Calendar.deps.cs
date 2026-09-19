using Violet.Scenes;
using Violet.Services;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	CalendarDependencies is a lightweight bundle of all the
	dependencies needed by component VMs of the Calendar scene.
*/


public class CalendarDependencies
{
	// --> add more dependencies here {r}
	public AppDataReadOnly ReadOnlyData { get; }
	public SelectionAPI SelectionApi { get; }
	public FocusAPI FocusApi { get; }
	public KeybindAPI KeybindApi { get; }
	
	public CalendarDependencies(
		AppDataReadOnly readOnlyData,
		SelectionAPI selectionApi,
		FocusAPI focusApi,
		KeybindAPI keybindApi
	)
	{
		ReadOnlyData = readOnlyData;
		SelectionApi = selectionApi;
		FocusApi = focusApi;
		KeybindApi = keybindApi;
	}
}