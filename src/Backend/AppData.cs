using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Violet.Models;

namespace Violet;

/* {#fff}
{ CLASS DESCRIPTION }
	AppData is the application-lifetime storage of all data. Data is
	centralized in this object, and Scenes are merely different presentations
	of the same set of data.
*/


public class AppData
{
	// --> PROPERTIES {r}
	public AppDataReadOnly ReadOnly { get; }
	public ObservableCollection<Task> Tasks { get; }
	public ObservableCollection<string> TaskTags { get; }

	
	// --> CONSTRUCTOR {v}
	public AppData()
	{
		Tasks = new ObservableCollection<Task>();
		TaskTags = new ObservableCollection<string>();
		TaskTags.Add("CMSC128");
		
		ReadOnly = new AppDataReadOnly(this);
	}
}