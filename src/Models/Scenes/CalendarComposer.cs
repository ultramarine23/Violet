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
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private AppDataReadOnly _appData;
	

	// --> 2: PROPERTIES {y}
	public ViewModelBase SceneVM { get; }
	

	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarScene(AppDataReadOnly appData)
	{
		_appData = appData;

		SceneVM = new CalendarSceneViewModel(this);
	}


	// --> 4: PUBLIC METHODS {b}
	//

	
	// --> 5: PRIVATE METHODS {v}
	//	
}