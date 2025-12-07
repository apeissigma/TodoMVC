using Microsoft.VisualBasic;
using TodoMVC.Models.TodoModels;
namespace TodoMVC.Models.ViewModels
{
    public class TodoVM : ITodoVM
    {
        //collection of tasks
        private static List<ITask> _tasks;

        public List<ITask> Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new List<ITask>()
                    {
                        new TodoTask(),
                        new TodoTask() { taskName = "Class Diagram UML", taskDescription = "UML for the model classes", dueDate = DateTime.Now.AddDays(3) },
                        new TodoTask() { taskName = "UI", taskDescription = "ummm yeah", dueDate = DateTime.Now.AddDays(3) },
                        new TodoTask() { taskName = "Tests", taskDescription = "MCFire coverage for model classes, view models, controllers", dueDate = DateTime.Now.AddDays(3) },
                        new TodoTask() { taskName = "finish this shit!", taskDescription = "Functional", dueDate = DateTime.Now.AddDays(3) }
                    };
                }
                return _tasks;
            }
        }
    }
}
