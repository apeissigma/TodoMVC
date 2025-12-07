using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoMVC.Models.TodoModels
{
    public interface ICompleteable
    {
        bool isComplete { get; }

        void markComplete();
        void markIncomplete();
        void toggleCompleteness(); 
    }
}