using System;
using System.Collections.Generic;
using Violet.Models;

namespace Violet.Pages;

public class CalendarComposer : ComposerBase
{
	private AppDataReadOnly _appData;
	
	public CalendarComposer(AppDataReadOnly appData)
	{
		_appData = appData;
	}


	
}