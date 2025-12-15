using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoMVC.Models;
using TodoMVC.Models.TodoModels;
using TodoMVC.Services;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService; //implement the service interface
        List<ITask> Tasks; 

        //constructor w/ dependency injection
        public TodoController(ITodoService todoService)
        {
            //store the injected dependency and reference the task list from the view model
            _todoService = todoService;
            Tasks = todoService.Tasks; 
        }

        //pass task list to index view to display all tasks
        public IActionResult Index()
        {
            return View(Tasks);
        }

        //mark task as complete or incomplete based on current state
        public ActionResult ToggleComplete(int id)
        {
            try
            {
                _todoService.ToggleTaskComplete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //get detail view of a task via it's id
        public ActionResult Details(int id)
        {
            try
            {
                ITask t = Tasks.FirstOrDefault(t => t.id == id);
                return View(t);
            }
            catch
            {
                return View(); 
            }
        }

        //get create page with form for creating a new task
        public ActionResult Create()
        {
            return View();
        }

        //processes form submission to create new task, maps form data to task object
        [HttpPost] //post requests only
        [ValidateAntiForgeryToken] 
        public ActionResult Create(TodoTask t) 
        {
            try
            {
                Tasks.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //get edit page with form for editing an existing task 
        public ActionResult Edit(int id)
        {
            ITask t = Tasks.FirstOrDefault(t => t.id == id);

            return View(t);
        }

        //processes form submission to edit an existing task, maps form data to task object
        //IFormCollection used to process form data 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection formData)
        {
            try
            {
                ITask t = Tasks.FirstOrDefault(t => t.id == id);

                //assign form data to task 
                t.taskName = formData["taskName"];
                t.taskDescription = formData["taskDescription"];
                t.dueDate = DateTime.Parse(formData["dueDate"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //deletes task by id (removes it from the task collection)
        public ActionResult Delete(int id)
        {
            try
            {
                ITask t = Tasks.FirstOrDefault(t => t.id == id);
                Tasks.Remove(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
