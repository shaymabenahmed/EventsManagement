using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class ParticipantsClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
