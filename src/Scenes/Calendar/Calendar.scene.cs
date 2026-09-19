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

	private readonly CalendarDependencies _dependencies;


	// --> 2: PROPERTIES (VMs) {y}
	public CalendarSceneViewModel SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarScene(
		AppDataReadOnly readOnlyData, 
		KeybindAPI keybindAPI,
		FocusAPI focusAPI
	) : base(keybindAPI, focusAPI)
	{
		_readOnlyData = readOnlyData;

		_dependencies = new CalendarDependencies(
			_readOnlyData, 
			_selectionAPI,
			_focusAPI,
			_keybindAPI
		);

		SceneVM = new CalendarSceneViewModel(_dependencies);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: INTERNAL METHODS {v}
	//
}