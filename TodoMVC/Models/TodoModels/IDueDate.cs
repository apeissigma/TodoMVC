using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoMVC.Models.TodoModels
{
    public interface IDueDate
    {
        DateTime dueDate { get; set; }
        bool isOverdue { get; set; }
    }
}