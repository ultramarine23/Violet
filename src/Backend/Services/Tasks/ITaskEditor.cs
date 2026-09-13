using Violet.Models;

namespace Violet.Services;

/* {#fff}
{ CLASS DESCRIPTION }
	Interface of [TaskService] that implements all methods relating to
	mutating specific tasks within the Tasks collection.
*/


public interface ITaskEditor
{
	public void MarkTaskAsDone(Task task);
	public void EditTaskData(Task task, TaskData taskData);
}