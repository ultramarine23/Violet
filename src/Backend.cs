using Violet.Models;
using Violet.Pages;
using Violet.Services;

namespace Violet;

public class Backend
{
    public AppData Data { get; set; }
    public AppDataReadOnly ReadOnlyData { get; set; }
	public ComposerBase? CurrentPage { get; set; }

    // services
    public TaskService TaskService { get; set; }


    public Backend()
    {
		CurrentPage = null;
        Data = new AppData();
        ReadOnlyData = Data.ReadOnly;

        TaskService = new TaskService(Data);
    } 


}