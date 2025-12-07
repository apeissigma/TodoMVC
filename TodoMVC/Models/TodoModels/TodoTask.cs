using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoMVC.Models.TodoModels
{
    public class TodoTask : ITask
    {
        private static int _id = 0; //made static so the id value property increments across all task instances

        //implement ITask
        public int id { get; private set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }

        //implement IDueDate
        public DateTime dueDate { get; set; }
        public bool isOverdue 
        { 
            get
            {
                DateTime dt = DateTime.Now;
                if (this.dueDate < dt) return true; 
                return false; 
            }
            set { isOverdue = value; }
        }

        //implement ICompleteable
        public bool isComplete { get; set; }


        //default constructor
        public TodoTask() 
        {
            taskName = "Default Name";
            taskDescription = "Default Description";
            dueDate = DateTime.Now.AddDays(7);
            isComplete = false;
            this.id = ++_id;
        }

        //implement ICompleteable
        public void markComplete()
        {
            isComplete = true;
        }
        public void markIncomplete()
        {
            isComplete = false;
        }
        public void toggleCompleteness()
        {
            if (!isComplete) isComplete = true;
            else isComplete = false; 
        }
               
    }
}
