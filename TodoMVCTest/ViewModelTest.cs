using TodoMVC.Models.ViewModels;
using TodoMVC.Models.TodoModels;

namespace TodoMVCTest
{
    public class ViewModelTest
    {
        [Fact]
        public void CreateViewModel_NotNull()
        {
            var todoVM = new TodoVM();

            Assert.NotNull(todoVM.Tasks);
            Assert.IsAssignableFrom<List<ITask>>(todoVM.Tasks);
        }

        [Fact]
        public void CreateViewModel_ImplementsInterface()
        {
            var todoVM = new TodoVM();

            Assert.IsAssignableFrom<ITodoVM>(todoVM);
        }
    }
}
