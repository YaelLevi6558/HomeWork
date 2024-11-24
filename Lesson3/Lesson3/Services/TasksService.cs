using Lesson3.Model;
using Lesson3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lesson3.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _taskRepository = tasksRepository;
        }
        public List<Tasks> GetAllTasks()
        {
            return _taskRepository.GetTask();
        }
        public List<Tasks> GetTasksByStatus(string status)
        {
            return _taskRepository.GetTasksByStatus(status);
        }
        public void AddTask(Tasks newTask)
        {
            _taskRepository.addTasks(newTask);
        }

        public void UpdateTaskById(Tasks task)
        {
           
            _taskRepository.updateTasks(task);
        }
        public void DeleteTaskById(int id)
        {
            _taskRepository.DeleteTaskById(id);
        }

        //public Tasks? GetTasksByProjectId(int projectId)
        //{
        //    List<Tasks> allTasks = _taskRepository.GetTask();
        //    return allTasks.FirstOrDefault(t => t.ProjectId == projectId);
        //}

    }
}
