/*
 * DateTime Contstructor Reference: 
 * https://learn.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=net-10.0#system-datetime-ctor(system-int32-system-int32-system-int32-system-globalization-calendar)
 */

using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography.X509Certificates;
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
                    SeedData();
                }
                return _tasks;
            }
        }

        //seed pre-made tasks at launch
        //very lightly supports SOC
        private void SeedData()
        {

            _tasks = new List<ITask>
            {
                new TodoTask() { taskName = "Class Diagram UML", taskDescription = "UML for the model classes", dueDate = new DateTime(2025, 12, 9, 12, 30, 0, 0), isComplete = true },
                new TodoTask() { taskName = "UI", taskDescription = "Functional presentation layer", dueDate = new DateTime(2025, 12, 9, 12, 30, 0, 0), isComplete = true },
                new TodoTask() { taskName = "Tests", taskDescription = "MCFire coverage for model classes & view models", dueDate = new DateTime(2025, 12, 9, 12, 30, 0, 0), isComplete = true }
            };
        }
    }
}
