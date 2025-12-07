/*
 * DateTime Contstructor Reference: 
 * https://learn.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=net-10.0#system-datetime-ctor(system-int32-system-int32-system-int32-system-globalization-calendar)
 */

using Microsoft.VisualBasic;
using System;
using TodoMVC.Models.TodoModels;
namespace TodoMVC.Models.ViewModels
{
    public class TodoVM : ITodoVM
    {
        //static collection for persistance across requests
        private static List<ITask> _tasks;

        //implement the ITodoVM interface
        public List<ITask> Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new List<ITask>()
                    {
                        //create some default tasks at launch
                        new TodoTask(),
                        new TodoTask() { taskName = "Class Diagram UML", taskDescription = "UML for the model classes", dueDate = DateTime.Now.AddDays(3) },
                        new TodoTask() { taskName = "UI", taskDescription = "Functional presentation layer", dueDate = new DateTime(2025, 12, 9, 12, 30, 0) },
                        new TodoTask() { taskName = "Tests", taskDescription = "MCFire coverage for model classes, view models, controllers", dueDate = new DateTime(2025, 12, 9, 12, 30, 0) },
                        new TodoTask() { taskName = "finish this shit!", taskDescription = "ummm yeah", dueDate = new DateTime(2025, 12, 9, 12, 30, 0) }
                    };
                }
                return _tasks;
            }
        }
    }
}
