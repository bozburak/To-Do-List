using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using ToDoList.Models;

namespace ToDoList.SiteHelper
{
    public static class TaskListHelper
    {
        public static TaskListModel.Rootobject DeseriliazeTaskListJson()
        {
            TaskListModel.Rootobject taskListModel = new TaskListModel.Rootobject();
            var json = System.IO.File.ReadAllText(@"D:\BB\GitHub\bozburak\ToDoList\ToDoList\DataSet\TaskList.json");
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(TaskListModel.Rootobject));
                taskListModel = (TaskListModel.Rootobject)deserializer.ReadObject(ms);
            }
            return taskListModel;
        }
        public static void SeriliazeAndUpdateTaskListJson(TaskListModel.Rootobject taskListModel)
        {
            string output = JsonConvert.SerializeObject(taskListModel);
            System.IO.File.WriteAllText(@"D:\BB\GitHub\bozburak\ToDoList\ToDoList\DataSet\TaskList.json", output);
        }
    }
}