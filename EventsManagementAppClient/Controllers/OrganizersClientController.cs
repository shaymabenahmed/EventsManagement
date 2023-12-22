using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class OrganizersClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
