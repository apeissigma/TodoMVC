using TodoMVC.ViewModels;
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

        [Fact]
        public void SeedDefaultData()
        {
            var todoVM = new TodoVM();

            int count = todoVM.Tasks.Count;

            Assert.Equal(3, count);
        }
    }
}
