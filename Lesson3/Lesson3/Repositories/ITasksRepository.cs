using Lesson3.Model;

namespace Lesson3.Repositories
{
    public interface ITasksRepository
    {
        void addTasks(Tasks task);
        List<Tasks> GetTask();
        List<Tasks> GetTasksByStatus(string status);
        void updateTasks(Tasks task);
        void DeleteTaskById(int id);


    }
}
