using Violet.Models;
using Violet.Pages;

public class Backend
{
    public TasksComposer Tasks { get; }
	public ComposerBase CurrentPage { get; set; }

    public Backend()
    {
        Tasks = new TasksComposer();

		CurrentPage = Tasks;
    } 
}