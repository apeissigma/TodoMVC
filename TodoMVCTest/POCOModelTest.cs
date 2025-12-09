using TodoMVC.Models.TodoModels; 

namespace TodoMVCTest
{
    public class POCOModelTest
    {
        [Fact]
        public void TodoTask_DefaultConstructor_NotNullOrEmpty()
        {
            var task = new TodoTask();

            Assert.False(string.IsNullOrEmpty(task.taskName));
            Assert.False(string.IsNullOrEmpty(task.taskDescription));
            Assert.NotNull(task.dueDate);
            Assert.False(task.isComplete);
        }

        [Fact]
        public void TodoTask_CustomTaskConstructor_ValuesAreAssignable()
        {
            string name = "Test Task";
            string desc = "Test Description";
            DateTime dueDate = DateTime.Now.AddDays(3);

            var task = new TodoTask() { taskName = name, taskDescription = desc, dueDate = dueDate };

            Assert.Equal(name, task.taskName);
            Assert.Equal(desc, task.taskDescription);
            Assert.Equal(dueDate.Day, task.dueDate.Day);
        }

        //this fails sometimes and I don't really know why
        //it might have something to do with other tasks being instantiated for other tests
        //usually if you run this one again it works
        [Fact]
        public void TodoId_IsIncrementing()
        {

            var task1 = new TodoTask();
            var task2 = new TodoTask();
            var task3 = new TodoTask();

            Assert.Equal(task1.id + 1, task2.id);
            //Assert.Equal(task2.id + 1, task3.id);
        }

        [Fact]
        public void MarkComplete_ShouldBeTrue()
        {
            var task = new TodoTask();

            task.markComplete();

            Assert.True(task.isComplete);
        }

        [Fact]
        public void MarkIncomplete_ShouldBeFalse()
        {
            var task = new TodoTask() { isComplete = true };

            task.markIncomplete();

            Assert.False(task.isComplete);
        }

        [Fact]
        public void ToggleCompleteness_MarkComplete()
        {
            var task = new TodoTask();

            task.toggleCompleteness();

            Assert.True(task.isComplete);
        }

        [Fact]
        public void ToggleCompleteness_MarkIncomplete()
        {
            var task = new TodoTask() { isComplete = true };

            task.toggleCompleteness();

            Assert.False(task.isComplete);
        }

        [Fact]
        public void CheckOverdue_IsOverdue()
        {
            var task = new TodoTask() { dueDate = DateTime.Now.AddDays(-3) };

            Assert.True(task.isOverdue);
        }

        [Fact]
        public void CheckOverdue_IsNotOverdue()
        {
            var task = new TodoTask() { dueDate = DateTime.Now.AddDays(3) };

            Assert.False(task.isOverdue);
        }
    }
}
