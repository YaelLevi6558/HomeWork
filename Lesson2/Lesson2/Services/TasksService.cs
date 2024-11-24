using Lesson2.Model;
using Lesson2.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lesson2.Services
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
            var allTask = _taskRepository.GetTask();
            return allTask.Where(x => x.status == status).ToList();
            //var task = allTask.FirstOrDefault(x => x.status == status);
            //if (task == null)
            //    return new List<Tasks>();
            //throw new NotImplementedException();

        }
        public List<Tasks> AddTask(Tasks newTask)
        {
            var GetTasks = _taskRepository.GetTask();
            newTask.id = GetTasks.Count + 1;
            GetTasks.Add(newTask);
            _taskRepository.SaveTasks(GetTasks);
            return GetTasks;
        }
        public Tasks? UpdateTaskById(string status, int id)
        {
            var allTasks = _taskRepository.GetTask();
            Tasks thisTask = allTasks.FirstOrDefault(t => t.id == id);
            if (thisTask == null)
            {
                return null;
            }
            thisTask.status = status;
            _taskRepository.SaveTasks(allTasks);
            return thisTask;
        }
        public Tasks? DeleteTaskById(int id)
        {
            var allTasks = _taskRepository.GetTask();
            Tasks thisTask = allTasks.FirstOrDefault(t => t.id == id);
            allTasks.Remove(thisTask);
            _taskRepository.SaveTasks(allTasks);
            return thisTask;
        }

        //public Tasks? GetTasksByProjectId(int projectId)
        //{
        //    List<Tasks> allTasks = _taskRepository.GetTask();
        //    return allTasks.FirstOrDefault(t => t.ProjectId == projectId);
        //}

    }
}
