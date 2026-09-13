using Violet.Models;
using Violet.Scenes;
using Violet.Services;

namespace Violet;

public class Backend
{
    // --> APP DATA {r}
    private AppData _data;
    public AppDataReadOnly ReadOnlyData { get; set; }


    // --> SERVICES {y}
    public TaskService TaskService { get; set; }


    // --> CONSTRUCTOR {b}
    public Backend()
    {
		_data = new AppData();
        ReadOnlyData = _data.ReadOnly;

        TaskService = new TaskService(_data);
    } 


    // --> maybe SAVE/LOAD here later? {v}
    //
}