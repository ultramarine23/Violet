using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Avalonia.Collections;
using Violet.Models;

namespace Violet;

public class AppDataReadOnly
{
	// --> INTERNALS {r}
	private readonly AppData _appData;


	// --> PROPERTIES {y}
	public ReadOnlyObservableCollection<Task> Tasks;


	// --> CONSTRUCTOR {b}
	public AppDataReadOnly(AppData appData)
	{
		_appData = appData;
		Tasks = new ReadOnlyObservableCollection<Task>(_appData.Tasks);
	}
}