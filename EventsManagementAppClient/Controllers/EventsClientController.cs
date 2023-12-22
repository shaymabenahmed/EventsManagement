using EventsManagementAppClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class EventsClientController : Controller
    {
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
    }
}
