using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using ToDoList.SiteHelper;
using ToDoList.Models;
using System;
using System.Linq;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var taskListModel = TaskListHelper.DeseriliazeTaskListJson();
            return View(taskListModel);
        }
        [HttpPost]
        public ActionResult Add(string value)
        {
            var taskListModel = TaskListHelper.DeseriliazeTaskListJson();
            var newId = Convert.ToUInt32(taskListModel.tasks.Count != 0 ? taskListModel.tasks.LastOrDefault().id : "0") + 1;
            taskListModel.tasks.Add(new TaskListModel.Task()
            {
                id = newId.ToString(),
                status = "0",
                value = value
            });
            TaskListHelper.SeriliazeAndUpdateTaskListJson(taskListModel);
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Remove(string id)
        {
            var taskListModel = TaskListHelper.DeseriliazeTaskListJson();
            var task = taskListModel.tasks.Where(x => x.id == id).FirstOrDefault();
            taskListModel.tasks.Remove(task);
            TaskListHelper.SeriliazeAndUpdateTaskListJson(taskListModel);
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Edit(TaskListModel.Task task)
        {
            var taskListModel = TaskListHelper.DeseriliazeTaskListJson();
            var editTask = taskListModel.tasks.Where(x => x.id == task.id).FirstOrDefault();
            editTask.status = task.status;
            editTask.value = task.value;
            TaskListHelper.SeriliazeAndUpdateTaskListJson(taskListModel);
            return Redirect("/");
        }
    }

}