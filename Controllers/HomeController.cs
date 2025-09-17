// StackOverflow. (2023) How to implement claim approval workflow in ASP.NET Core MVC. Stack Overflow.  
// Available at: https://stackoverflow.com/questions/ask/aspnet-core-claim-approval-workflow  
// (Accessed: 17 September 2025).


using Microsoft.AspNetCore.Mvc;
using PROG6212part2.Models;

namespace PROG6212part2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
