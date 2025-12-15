using TodoMVC.Models.TodoModels; 
namespace TodoMVC.Services
{
    public interface ITodoService
    {
        //separated into an interface for separation of concern
        List<ITask> Tasks { get; }
        ITask GetTaskById(int id);

        void ToggleTaskComplete(int id);
    }
}
