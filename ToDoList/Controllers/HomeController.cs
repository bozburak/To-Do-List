using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            TaskListModel.Rootobject taskListModel = new TaskListModel.Rootobject();
            var asasdd = System.IO.File.ReadAllText(@"D:\BB\GitHub\ToDoList\ToDoList\DataSet\TaskList.json");
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(asasdd)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(TaskListModel.Rootobject));
                taskListModel = (TaskListModel.Rootobject)deserializer.ReadObject(ms);
            }
            return View(taskListModel);
        }
        [HttpPost]
        public ActionResult Add(string task)
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Remove(string key)
        {
            return View();
        }
        [HttpPut]
        public ActionResult Edit(string key)
        {
            return View();
        }
    }

}