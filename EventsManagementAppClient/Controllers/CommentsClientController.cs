using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class CommentsClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
