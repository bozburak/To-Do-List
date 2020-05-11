using System.Collections.Generic;

namespace ToDoList.Models
{
    public class TaskListModel
    {
        public class Rootobject
        {
            public List<Task> tasks { get; set; }
        }

        public class Task
        {
            public string id { get; set; }
            public string value { get; set; }
            public string status { get; set; }
        }
    }
}