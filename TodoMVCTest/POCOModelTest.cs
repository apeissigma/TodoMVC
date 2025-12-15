using TodoMVC.Models.TodoModels; 

namespace TodoMVCTest
{
    public class POCOModelTest
    {
        public POCOModelTest()
        {
            TodoTask.ResetIdCounter(); 
        }

        [Fact]
        public void TodoTask_DefaultConstructor_NotNullOrEmpty()
        {
            //arrange & act
            var task = new TodoTask();

            //assert
            Assert.False(string.IsNullOrEmpty(task.taskName));
            Assert.False(string.IsNullOrEmpty(task.taskDescription));
            Assert.NotNull(task.dueDate);
            Assert.False(task.isComplete);
        }

        [Fact]
        public void TodoTask_CustomTaskConstructor_ValuesAreAssignable()
        {
            //arrange
            string name = "Test Task";
            string desc = "Test Description";
            DateTime dueDate = new DateTime(2024, 12, 25, 14, 30, 0);

            //act
            var task = new TodoTask() { taskName = name, taskDescription = desc, dueDate = dueDate };

            //assert
            Assert.Equal(name, task.taskName);
            Assert.Equal(desc, task.taskDescription);
            Assert.Equal(dueDate, task.dueDate);
        }

        [Fact]
        public void TodoId_IsIncrementing()
        {
            //act & arrange
            TodoTask.ResetIdCounter(); 
            var task1 = new TodoTask();
            var task2 = new TodoTask();
            var task3 = new TodoTask();

            //assert
            Assert.Equal(0, task1.id);
            Assert.Equal(1, task2.id);
            Assert.Equal(2, task3.id);
            Assert.NotEqual(task1.id, task2.id);
            Assert.NotEqual(task2.id, task3.id);
        }

        [Fact]
        public void MarkComplete_ShouldBeTrue()
        {
            //arrange
            var task = new TodoTask();

            //act
            task.markComplete();

            //assert
            Assert.True(task.isComplete);
        }

        [Fact]
        public void MarkIncomplete_ShouldBeFalse()
        {
            //arrange
            var task = new TodoTask() { isComplete = true };

            //act
            task.markIncomplete();

            //assert
            Assert.False(task.isComplete);
        }

        [Fact]
        public void ToggleCompleteness_MarkComplete()
        {
            //arrange
            var task = new TodoTask();

            //act
            task.toggleCompleteness();

            //assert
            Assert.True(task.isComplete);
        }

        [Fact]
        public void ToggleCompleteness_MarkIncomplete()
        {
            //arrange
            var task = new TodoTask() { isComplete = true };

            //act
            task.toggleCompleteness();

            //assert
            Assert.False(task.isComplete);
        }

        [Fact]
        public void CheckOverdue_IsOverdue()
        {
            //arrange & act
            DateTime dueDate = new DateTime(2024, 1, 1, 12, 0, 0);
            var task = new TodoTask() { dueDate = dueDate };

            //assert
            Assert.True(task.isOverdue);
        }

        [Fact]
        public void CheckOverdue_IsNotOverdue()
        {
            //arrange & act
            DateTime dueDate = DateTime.Now.AddDays(3);
            var task = new TodoTask() { dueDate = dueDate };

            //assert
            Assert.False(task.isOverdue);
        }
    }
}
