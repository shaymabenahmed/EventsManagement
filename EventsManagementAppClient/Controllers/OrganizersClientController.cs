using EventsManagementAppClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class OrganizersClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllOrganizers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync(
                "api/Organizers/get-all-organizers"
                );
            if (response.IsSuccessStatusCode)
            {
                var organizers = await response.Content.ReadFromJsonAsync<IEnumerable<OrganizerClient>>();
                return View(organizers);
            }
            else
            {
                return View();
            }

        }

        public async Task<ActionResult> GetOrganizerById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            HttpResponseMessage response = await client.GetAsync("api/Organizers/get-organizer-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var organizerDetail = await response.Content.ReadFromJsonAsync<IEnumerable<EventClient>>();
                return View(organizerDetail);
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> CreateOrganizer(OrganizerClient organizerClient)

        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Organizers/create-organizer", organizerClient);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("get-all-organizers");
                }
                else
                {
                    return View();
                }
            }
            return View(organizerClient);
        }

        public async Task<ActionResult> EditOrganizer(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Organizers/edit-organizer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var organizerDetail = await response.Content.ReadFromJsonAsync<OrganizerClient>();
                return View(organizerDetail);
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteOrganizer(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Organizers/delete-organizer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var organizertDetail = await response.Content.ReadFromJsonAsync<OrganizerClient>();
                return View(organizertDetail);
            }
            else
            {
                return View("Error");
            }
        }


    }
}
