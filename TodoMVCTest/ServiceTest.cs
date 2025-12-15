/*
    Disabled running tests in parallel
    Reference: https://xunit.net/docs/running-tests-in-msbuild
 */

using TodoMVC.Models.TodoModels;
using TodoMVC.Services;

namespace TodoMVCTest
{
    public class ServiceTest
    {
        
        [Fact]
        public void CreateService_NotNull()
        {
            //arrange & act
            var service = new TodoService();

            //assert
            Assert.NotNull(service.Tasks);
            Assert.IsAssignableFrom<List<ITask>>(service.Tasks);
        }

        [Fact]
        public void CreateService_ImplementsInterface()
        {
            //arrange & act
            var service = new TodoService();

            //assert
            Assert.IsAssignableFrom<ITodoService>(service);
        }

        [Fact]
        public void DefaultDataSeeded()
        {
            //arrange & act
            TodoService.ClearCollection(); //resets service's data 
            var service = new TodoService(); //should be instantiated with 3 dummy tasks
            int count = service.Tasks.Count;

            //assert
            Assert.Equal(3, count);
        }

        [Fact]
        public void ToggleTask_IncompleteToComplete()
        {
            //arrange
            var service = new TodoService();
            
            //act
            service.Tasks.Add(new TodoTask() 
            { 
                taskName = "test", 
                taskDescription = "test", 
                dueDate = new DateTime(2025, 12, 9, 12, 30, 0, 0), 
                isComplete = false 
            });
            var lastTaskIndex = service.Tasks.Count - 1;
            var lastTask = service.Tasks[lastTaskIndex];
            service.ToggleTaskComplete(lastTask.id);

            //assert
            Assert.True(lastTask.isComplete);
        }

        public void ToggleTask_CompleteToIncomplete()
        {
            //arrange
            var service = new TodoService();

            //act
            service.Tasks.Add(new TodoTask()
            {
                taskName = "test",
                taskDescription = "test",
                dueDate = new DateTime(2025, 12, 9, 12, 30, 0, 0),
                isComplete = true
            });
            var lastTaskIndex = service.Tasks.Count - 1;
            var lastTask = service.Tasks[lastTaskIndex];
            service.ToggleTaskComplete(lastTask.id);

            //assert
            Assert.False(lastTask.isComplete);
        }
    }
}
