using System;
using System.Collections.Generic;
using Violet.Models;
using Violet.ViewModels;

namespace Violet.Scenes;

/* {#fff}
{ CLASS DESCRIPTION }
	CalendarComposer is the composer for the CalendarScene.
	(see [ComposerBase] for more details)
*/


public class CalendarComposer : ComposerBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private AppDataReadOnly _appData;
	

	// --> 2: PROPERTIES {y}
	public ViewModelBase SceneModel { get; }
	

	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarComposer(AppDataReadOnly appData)
	{
		_appData = appData;

		SceneModel = new CalendarSceneModel(this);
	}


	// --> 4: PUBLIC METHODS {b}
	//

	
	// --> 5: PRIVATE METHODS {v}
	//	
}