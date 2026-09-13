using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.ViewModels;

namespace Violet.Scenes;

/* {#fff}
{ CLASS DESCRIPTION }
	CalendarScene is the scene for the CalendarScene.
	(see [SceneBase] for more details)
*/


public class CalendarScene : SceneBase
{
	// --> 1: INTERNALS {r}
	private readonly AppDataReadOnly _readOnlyData;
	private readonly CalendarSAPI _sceneApi;

	private readonly CalendarDependencies _dependencies;


	// --> 2: PROPERTIES (VMs) {y}
	public CalendarSceneViewModel SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarScene(AppDataReadOnly readOnlyData) : base()
	{
		_readOnlyData = readOnlyData;
		_sceneApi = new CalendarSAPI(this);

		_dependencies = new CalendarDependencies(
			_readOnlyData, 
			_sceneApi
		);

		SceneVM = new CalendarSceneViewModel(_dependencies);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	//
}