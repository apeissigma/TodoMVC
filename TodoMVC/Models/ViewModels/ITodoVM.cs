using TodoMVC.Models.TodoModels; 
namespace TodoMVC.Models.ViewModels
{
    public interface ITodoVM
    {
        List<ITask> Tasks { get; }
    }
}
