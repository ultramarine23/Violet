using Violet.Models;
using Violet.Scenes;
using Violet.Services;

namespace Violet;

public class Backend
{
    // --> 
    private AppData _data;

    public AppDataReadOnly ReadOnlyData { get; set; }
	public ComposerBase? CurrentPage { get; set; }


    // --> SERVICES {g}
    public TaskService TaskService { get; set; }


    // --> CONSTRUCTOR {v}
    public Backend()
    {
		_data = new AppData();
        
        CurrentPage = null;
        ReadOnlyData = _data.ReadOnly;

        TaskService = new TaskService(_data);
    } 


}