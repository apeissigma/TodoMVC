using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TodoMVC.Models.TodoModels
{
    public class TodoTask : IDueDate, IAssignable, ICompleteable
    {
        //id
        public int id { get; set; }
        private int _id;

        public string taskName { get; set; }

        //implement IDueDate
        public DateTime dueDate { get; set; }
        public bool isOverdue { get; set; }

        //implement ICompleteable
        public bool isComplete { get; set; }

        //implement IAssignable
        public bool isAssigned { get; set; }

        public Account assignee { get; set; }

        //default constructor
        public TodoTask() 
        {
            taskName = "test";
            dueDate = DateTime.Now.Date.AddDays(7);
            isComplete = false;
            isAssigned = false;
            this.id = _id++;
        }

        public TodoTask(string tName)
        {
            taskName = tName;
            dueDate = DateTime.Now.Date.AddDays(7);
            isComplete = false;
            isAssigned = false;
            this.id = _id++;
        }
        public TodoTask(string tName, int daysUntilDue)
        {
            taskName = tName;
            dueDate = DateTime.Now.Date.AddDays(daysUntilDue); 
            isComplete = false;
            isAssigned = false;
            this.id = _id++;
        }
        public TodoTask(string tName, Account account)
        {
            taskName = tName;
            dueDate = DateTime.Now.Date.AddDays(7); 
            isComplete = false;
            isAssigned = true;
            assignee = account;
            this.id = _id++;
        }
        public TodoTask(string tName, int daysUntilDue, Account account)
        {
            taskName = tName;
            dueDate = DateTime.Now.Date.AddDays(daysUntilDue);
            isComplete = false;
            isAssigned = true;
            assignee = account;
            this.id = _id++;
        }


        //implement IDueDate
        public bool checkIfOverdue()
        {
            if (isOverdue) return true;
            else return false; 
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
        public bool checkIfComplete()
        {
            if (isComplete) return true;
            else return false;
        }

        //implement IAssignable
        public string assignTo(Account account)
        {
            if (isAssigned) return "This task has already been assigned.";
            assignee = account;
            isAssigned = true;
            return $"This task has been assigned to {account.FirstName} {account.LastName}.";
        }


 
        public string DisplayTask()
        {
            StringBuilder sb = new StringBuilder();

            /*
            sb.Append("-------------------------\n");
            sb.Append($"{this.taskName}\n");
            sb.Append("-------------------------\n");

            if (this.isComplete) sb.Append($"Status: Complete\n");
            else sb.Append($"Status: Not started\n");

            sb.Append($"Due Date: {dueDate} ");
            if (this.isOverdue) sb.Append("(Overdue)");

            if (this.isAssigned) sb.Append($"Assigned to: {this.assignee.FirstName} {this.assignee.LastName}");
            */

            if (this == null)
            {
                return "no task found";
            }

            if (taskName != null) { sb.Append(taskName + "\n"); }
                else sb.Append("null");

            sb.Append("Due Date: ");
            if (dueDate != null) { sb.Append(dueDate.Date + "\n"); }
                else sb.Append("null");

            sb.Append("Assigned to: ");
            if (assignee != null) { sb.Append(assignee.FirstName + " " + assignee.LastName); }
                else sb.Append("null");

            return sb.ToString();
        }

    }
}
