using Microsoft.AspNetCore.Mvc;

namespace ToDoTask.Controllers
{
    public class ToDoTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
