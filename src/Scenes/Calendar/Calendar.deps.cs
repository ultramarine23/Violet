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
	public CalendarSAPI SceneApi { get; }

	
	public CalendarDependencies(
		AppDataReadOnly readOnlyData,
		CalendarSAPI sceneApi
	)
	{
		ReadOnlyData = readOnlyData;
		SceneApi = sceneApi;
	}
}