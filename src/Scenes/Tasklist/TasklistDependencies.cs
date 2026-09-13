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
	public TasklistSAPI SceneApi { get; }
	public TaskService TaskService { get; }

	
	public TasklistDependencies(
		AppDataReadOnly readOnlyData,
		TasklistSAPI sceneApi,
		TaskService taskService
	)
	{
		ReadOnlyData = readOnlyData;
		SceneApi = sceneApi;
		TaskService = taskService;
	}
}