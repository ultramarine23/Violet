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
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly CalendarScene _tasksPage;
	

	// --> 2: PROPERTIES {y}
	// empty... for now >:))


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarSceneViewModel(CalendarScene calendarScene)
	{
		_tasksPage = calendarScene;
	}

	public override void Dispose()
	{
		// doesnt need to destruct anything
	}
	

	// --> 4: PUBLIC METHODS {b}
	// empty... for now >:))


	// --> 5: PRIVATE METHODS {v}
	// empty... for now >:))



}
