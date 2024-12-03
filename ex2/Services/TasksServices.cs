using ex2.Models;
using ex2.Repositories;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using TasksApi.Services.Logger;
using static System.Reflection.Metadata.BlobBuilder;
namespace ex2.Services
{
    public class TasksServices:ITasksServices
    {
        private readonly ITasksRepository _TasksRepository;
        private readonly ILoggerService _logger;

        public TasksServices(ITasksRepository TasksRepository, ILoggerService logger)
        {
            _TasksRepository = TasksRepository;
            _logger = logger;
        }

        public void Add(Tasks task)
        {
             _TasksRepository.add(task);
            _logger.Log("משימה נוספה בהצלחה✔");
        }

        public void addByUser(Tasks task)
        {
            _TasksRepository.addByUser(task);
        }

        public void Delete(int id)
        {
            var Tasks = Get();
            Tasks Task = Tasks.FirstOrDefault(i => i.Id == id);
             _TasksRepository.delete(Task);

        }

        public IEnumerable<Tasks> Get()
        {
            return _TasksRepository.Get();
            _logger.Log("משימה נשלפה בהצלחה✔");

        }

        public List<Tasks> GetAllGetByUserName(string name)
        {
           return _TasksRepository.GetByUserName(name);
        }

        public void Update(Tasks task)
        {
            _TasksRepository.update(task);
        }        
    }
}
