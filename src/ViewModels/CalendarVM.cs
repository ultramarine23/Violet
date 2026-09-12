using System;
using Violet.Pages;

namespace Violet.ViewModels;

/* {#fff}
{ CLASS DESCRIPTION }
	CalendarSceneModel is the VM connecting the CalendarComposer 
	and CalendarScene.
*/


public partial class CalendarSceneModel : ViewModelBase
{
	// --> 1: CONSTS, STATICS, FIELDS {r}
	private readonly CalendarComposer _tasksPage;
	

	// --> 2: PROPERTIES {y}
	// empty... for now >:))


	// --> 3: CONSTRUCTORS AND DESTRUCTORS {g}
	public CalendarSceneModel(CalendarComposer calendarComposer)
	{
		_tasksPage = calendarComposer;
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
