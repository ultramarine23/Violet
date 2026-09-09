using System.Collections.Generic;
using System.Threading.Tasks;

namespace Violet;

public class AppData
{
	public List<Task> tasks;
	
	public AppData()
	{
		tasks = new List<Task>();
	}
}