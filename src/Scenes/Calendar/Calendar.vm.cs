using System;
using Violet.Scenes;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	CalendarSceneViewModel is the VM connecting the CalendarScene 
	and CalendarScene.
*/


public partial class CalendarSceneViewModel : ViewModelBase
{
	// --> 1: INTERNALS {r}
	private readonly CalendarDependencies _dependencies;
	

	// --> 2: PROPERTIES {y}
	// empty... for now >:))


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarSceneViewModel(CalendarDependencies dependencies)
	{
		_dependencies = dependencies;
	}

	public override void Dispose()
	{
		// doesnt need to destruct anything
	}
	

	// --> 4: RELAY METHODS {b}
	// empty... for now >:))


	// --> 5: INTERNAL METHODS {v}
	// empty... for now >:))


}
