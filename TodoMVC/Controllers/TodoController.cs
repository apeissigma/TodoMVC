using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoMVC.Models;
using TodoMVC.Models.TodoModels;
using TodoMVC.Models.ViewModels;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        //request the interface (Debug fix)
        private readonly ITodoVM _todoVM; 

        List<TodoTask> Tasks; 

        //using view model list
        public TodoController(ITodoVM vm)
        {
            _todoVM = vm;
            Tasks = vm.Tasks; 
        }



        //Get controller/pass task list to index controller
        public IActionResult Index()
        {
            return View(Tasks);
        }


        //mark task as complete
        public ActionResult MarkComplete(int id)
        {
            TodoTask t = Tasks.FirstOrDefault(t => t.id == id);
            if (t != null) t.toggleCompleteness();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //get details
        public ActionResult Details(int id)
        {
            TodoTask t = Tasks.FirstOrDefault(t => t.id == id);
            return View(t);
        }

        //get create page
        public ActionResult Create()
        {
            return View();
        }

        // POST: create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //if you can pull a task out of the forms header, pull it out and add it
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

        // GET: edit
        public ActionResult Edit(int id)
        {
            TodoTask t = Tasks.FirstOrDefault(t => t.id == id);

            return View(t);
        }

        // POST: edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                TodoTask t = Tasks.FirstOrDefault(t => t.id == id);

                t.taskName = collection["Name"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: delete
        public ActionResult Delete(int id)
        {
            TodoTask t = Tasks.FirstOrDefault(t => t.id == id);
            Tasks.Remove(t);
            return RedirectToAction(nameof(Index));
        }

        // POST: delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TodoTask t = Tasks.FirstOrDefault(t => t.id == id);
                Tasks.Remove(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("View");
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
