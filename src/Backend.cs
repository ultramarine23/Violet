using Violet.Models;
using Violet.Pages;


public class Backend
{
    public AppData Data { get; set; }
	public ComposerBase CurrentPage { get; set; }

    public Backend()
    {
		CurrentPage = new TasklistComposer();
        Data = new AppData();
    } 


}