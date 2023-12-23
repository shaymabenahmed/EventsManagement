using EventsManagement_Chayma.Models;
using EventsManagementAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EventsManagementAppClient.Controllers
{
    public class EventsClientController : Controller
    {
        private readonly EventsDbContext _context;

        public EventsClientController(EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllEvents()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync(
                "api/Events/get-all-events"
                );
            if (response.IsSuccessStatusCode)
            {
                var events = await response.Content.ReadFromJsonAsync<IEnumerable<EventClient>>();
                return View(events);
            }
            else
            {
                return View();
            }

        }

        public async Task<ActionResult> GetEventById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            HttpResponseMessage response = await client.GetAsync($"api/Events/get-event-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var eventDetail = await response.Content.ReadFromJsonAsync<EventClient>();
                return View(eventDetail);
            }
            else
            {
                return View();
            }
        }




        public async Task<ActionResult> CreateEvent(EventClient eventClient)

        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Events/create-event", eventClient);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllEvents");
                }
                else
                {
                    return View();
                }
            }
            return View(eventClient);
        }

        // GET: Events/EditEvent/{id}
        public async Task<ActionResult> EditEvent(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Events/edit-event/{id}");
            if (response.IsSuccessStatusCode)
            {
                var eventDetail = await response.Content.ReadFromJsonAsync<EventClient>();
                return View(eventDetail);
            }
            else
            {
                return View();
            }
        }

        // GET: Events/DeleteEvent/{id}
        public async Task<ActionResult> DeleteEvent(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Events/delete-event/{id}");
            if (response.IsSuccessStatusCode)
            {
                var eventDetail = await response.Content.ReadFromJsonAsync<EventClient>();
                return View(eventDetail);
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> EventsAndTheirOrganizers()
        {
            var EventsDbContext = _context.Events.Include(m => m.Organizer);
            return View(await EventsDbContext.ToListAsync());
        }

        public IActionResult SearchByTitle(string title)
        {
            var events = _context.Events;
            if (title == null)
            {
                return View(events.ToList());
            }
            var FM = from e in events where e.Title.Contains(title) select e;
            return View(FM.ToList());
        }
    }
}
