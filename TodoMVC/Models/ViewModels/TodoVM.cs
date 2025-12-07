using TodoMVC.Models.TodoModels;
namespace TodoMVC.Models.ViewModels
{
    public class TodoVM : ITodoVM
    {
        //collection of tasks
        private static List<TodoTask> _tasks;

        public List<TodoTask> Tasks
        {
            //lazy loading
            get
            {
                if (_tasks == null)
                {
                    _tasks = new List<TodoTask>()
                    {
                        new TodoTask() { }
                    };
                }
                return _tasks;
            }
        }
    }
}
