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
	// inherits protected AppDataReadOnly _readOnlyData;


	// --> 2: PROPERTIES {y}
	public ViewModelBase SceneVM { get; }


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public TasklistScene(AppDataReadOnly readOnlyData) : base(readOnlyData)
	{
		SceneVM = new CalendarSceneViewModel(this, readOnlyData);
	}


	// --> 4: PUBLIC METHODS {b}
	//


	// --> 5: PRIVATE METHODS {v}
	//
}