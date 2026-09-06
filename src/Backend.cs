using Violet.Models;
using Violet.Pages;

public class Backend
{
    public TasksPage Tasks { get; }
	public PageBase CurrentPage { get; set; }

    public Backend()
    {
        Tasks = new TasksPage();

		CurrentPage = Tasks;
    }
}