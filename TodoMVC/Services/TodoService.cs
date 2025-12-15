/*
 * DateTime Contstructor Reference: 
 * https://learn.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=net-10.0#system-datetime-ctor(system-int32-system-int32-system-int32-system-globalization-calendar)
 */

using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography.X509Certificates;
using TodoMVC.Models.TodoModels;

namespace TodoMVC.Services
{
    //***VERSION 2 UPDATE***
    //"ViewModel" and service has been combined into a comprehensive repository (task list) and service (for modifying data) for simplicity
    public class TodoService : ITodoService
    {
        //static collection for persistance across requests
        private static List<ITask> _tasks;

        //tracks initialization to debug static collection
        private static bool _isInitialized = false; 

        //implement the ITodoVM interface
        public List<ITask> Tasks
        {
            get
            {
                if (!_isInitialized)
                {
                    SeedData();
                    _isInitialized = true;
                }
                return _tasks; 
            }
        }

        public ITask GetTaskById(int id)
        {
            foreach (ITask task in _tasks)
            {
                if (task.id == id) return task;
            }
            return _tasks[0];
        }

        public void ToggleTaskComplete(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.toggleCompleteness();
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

        //clears collection in case of overlaps
        public static void ClearCollection()
        {
            _tasks = null;
            _isInitialized = false; 
        }
    }
}
