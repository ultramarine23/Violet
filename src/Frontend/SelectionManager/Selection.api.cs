namespace Violet;

public class SelectionAPI
{
	private SelectionManager _manager;
	
	public SelectionAPI(SelectionManager manager)
	{
		_manager = manager;
	}

	// API-accessible methods {r}
	public void GrabSelection(ISelectCandidate target)
	{
		_manager.GrabSelection(target);
	}

	public void ReleaseSelection()
	{
		_manager.ReleaseSelection();
	}
}