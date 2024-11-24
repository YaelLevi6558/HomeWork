using Lesson2.Model;
using System.Text.Json;

namespace Lesson2.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly string _filePath = "Tasks.json"; 

        public List<Tasks> GetTask()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Tasks>(); 
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Tasks>>(jsonData);
        }

        public void SaveTasks(List<Tasks> tasks)
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            //למחרוזת jsonממיר מ
            var jsonData = JsonSerializer.Serialize(tasks);
            //מחזיר משימות כמחרוזת 
            File.WriteAllText(_filePath, jsonData);
        }
        public Tasks DeleteTaskById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
