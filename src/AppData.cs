using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Violet.Models;

namespace Violet;

public class AppData
{
	public AppDataReadOnly ReadOnly { get; }
	
	public ObservableCollection<Task> Tasks { get; }

	
	public AppData()
	{
		Tasks = new ObservableCollection<Task>();

		ReadOnly = new AppDataReadOnly(this);
	}
}