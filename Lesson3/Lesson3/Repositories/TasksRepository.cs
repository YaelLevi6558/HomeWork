using Lesson3.Model;
using Lesson3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Lesson3.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TasksDbContext _context;

        public TasksRepository(TasksDbContext context)
        {
            _context = context;
        }
        public List<Tasks> GetTask()
        {
            return _context.Tasks.ToList();
        }
        public void DeleteTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
        public void updateTasks(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
        public List<Tasks> GetTasksByStatus(string status)
        {
            var task = _context.Tasks.Where(x => x.status == status).ToList();
            return task;
        }

        public void addTasks(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        //public List<Tasks> AddTask(Tasks newTask)
        //{
        //    var GetTasks = _taskRepository.GetTask();
        //    newTask.id = GetTasks.Count + 1;
        //    GetTasks.Add(newTask);
        //    _taskRepository.SaveTasks(GetTasks);
        //    return GetTasks;
        //}
    }
}
