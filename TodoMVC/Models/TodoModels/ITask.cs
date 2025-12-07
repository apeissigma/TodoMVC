namespace TodoMVC.Models.TodoModels
{
    public interface ITask : ICompleteable, IDueDate
    {
        int id { get; }
        string taskName { get; set; }
        string taskDescription { get; set; }
    }
}
