using Lesson2.Model;

namespace Lesson2.Services
{
    public interface ITasksService
    {
        List<Tasks> GetAllTasks();
        List<Tasks> GetTasksByStatus(string status);
        List<Tasks> AddTask(Tasks newTask);
        Tasks? UpdateTaskById(string status, int id);
        Tasks? DeleteTaskById(int id);
        //Tasks? GetTasksByProjectId(int projectId);
    }
}
