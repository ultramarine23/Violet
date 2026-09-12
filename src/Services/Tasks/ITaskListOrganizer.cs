using Violet.Models;

namespace Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	Interface of [TaskService] that implements all methods relating to
	moving and reordering tasks within the list (no adding/deleting)
*/


public interface ITaskListOrganizer
{
	public void MoveTask(Task task, int newPosition);
	public void SortTasks(TaskSortMode mode);

}