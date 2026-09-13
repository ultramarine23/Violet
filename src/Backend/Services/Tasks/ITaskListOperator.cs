using Violet.Models;

namespace Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	Interface of [TaskService] that implements all methods relating to
	adding/deleting tasks from the Tasks collection.
*/


public interface ITaskListOperator
{
	public void AddTask(Task task);
	public void RemoveTask(Task task);
}