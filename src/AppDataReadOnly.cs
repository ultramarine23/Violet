using System.Collections.ObjectModel;
using Violet.Models;

namespace Violet;

public class AppDataReadOnly
{
	private readonly AppData _appData;

	public ReadOnlyObservableCollection<Task> Tasks;
	
	public AppDataReadOnly(AppData appData)
	{
		_appData = appData;

		Tasks = new ReadOnlyObservableCollection<Task>(appData.Tasks);
	}

}