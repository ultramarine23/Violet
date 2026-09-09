using Violet.Models;
using Violet.Pages;
using Violet.Services;

namespace Violet;

public class Backend
{
    public AppData Data { get; set; }
	public ComposerBase? CurrentPage { get; set; }

    // services
    public TaskService TaskService { get; set; }


    public Backend()
    {
		CurrentPage = null;
        Data = new AppData();

        TaskService = new TaskService(Data);
    } 


}