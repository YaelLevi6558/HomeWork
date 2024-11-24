using Lesson3.Model;

namespace Lesson3.Services
{
    public interface ITasksService
    {
        List<Tasks> GetAllTasks();
        List<Tasks> GetTasksByStatus(string status);
        void AddTask(Tasks newTask);
        void UpdateTaskById(Tasks task);
        void DeleteTaskById(int id);
        //Tasks? GetTasksByProjectId(int projectId);
    }
}
