namespace ToDoList.Models
{
    public class TaskListModel
    {
        public class Rootobject
        {
            public Task[] tasks { get; set; }
        }

        public class Task
        {
            public string id { get; set; }
            public string value { get; set; }
        }
    }
}