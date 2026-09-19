using Violet.Scenes;
using Violet.Services;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	TasklistDependencies is a lightweight bundle of all the
	dependencies needed by component VMs of the Tasklist scene.
*/


public class TasklistDependencies
{
	// --> add more dependencies here {r}
	public AppDataReadOnly ReadOnlyData { get; }
	public SelectionAPI SelectionApi { get; }
	public FocusAPI FocusApi { get; }
	public KeybindAPI KeybindApi { get; }
	
	public TaskService TaskService { get; }

	
	public TasklistDependencies(
		AppDataReadOnly readOnlyData,
		SelectionAPI selectionApi,
		FocusAPI focusApi,
		KeybindAPI keybindApi,
		TaskService taskService
	)
	{
		ReadOnlyData = readOnlyData;
		SelectionApi = selectionApi;
		FocusApi = focusApi;
		KeybindApi = keybindApi;
		TaskService = taskService;
	}
}