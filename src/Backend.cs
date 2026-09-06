using Violet.Models;
using Violet.Pages;

public class Backend
{
    public TasklistComposer Tasklist { get; }
	public ComposerBase CurrentPage { get; set; }

    public Backend()
    {
        Tasklist = new TasklistComposer();

		CurrentPage = Tasklist;
    } 
}