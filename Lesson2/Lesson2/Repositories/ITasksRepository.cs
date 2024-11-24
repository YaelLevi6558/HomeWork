using Lesson2.Model;

namespace Lesson2.Repositories
{
    public interface ITasksRepository
    {
        List<Tasks> GetTask();
        void SaveTasks(List<Tasks> books);
        Tasks DeleteTaskById(string id);

    }
}
