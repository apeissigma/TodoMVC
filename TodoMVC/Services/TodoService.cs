using TodoMVC.ViewModels;

namespace TodoMVC.Services
{
    public class TodoService: ITodoService
    {
        private readonly ITodoVM _vm;

        public TodoService(ITodoVM vm)
        {
            _vm = vm;
        }

        public void ToggleTaskComplete(int id)
        {
            var task = _vm.GetTaskById(id);
            if (task != null)
            {
                task.toggleCompleteness();
            }
        }
    }
}
