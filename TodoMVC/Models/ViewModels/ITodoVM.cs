using TodoMVC.Models.TodoModels; 
namespace TodoMVC.Models.ViewModels
{
    public interface ITodoVM
    {
        //separated into an interface for separation of concern
        List<ITask> Tasks { get; }
    }
}
