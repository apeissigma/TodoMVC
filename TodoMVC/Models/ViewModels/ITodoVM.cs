using TodoMVC.Models.TodoModels; 
namespace TodoMVC.Models.ViewModels
{
    public interface ITodoVM
    {
        //dog service/dog repo from dog service would go here (if I had one)
        //exposes a list of dog objects iwth a getter
        List<TodoTask> Tasks { get; } //private instance data member
    }
}
