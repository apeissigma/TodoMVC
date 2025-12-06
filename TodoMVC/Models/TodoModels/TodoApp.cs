using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoMVC.Models.TodoModels
{
    public class TodoApp
    {
        public List<TodoTask> tasks;

        public TodoApp()
        {
            tasks = new List<TodoTask>();
        }

        /*
        public void ViewTasks()
        {
            foreach (TodoTask task in Tasks)
            {
                task.DisplayTask(); 
            }
        }
        */
    }
}
