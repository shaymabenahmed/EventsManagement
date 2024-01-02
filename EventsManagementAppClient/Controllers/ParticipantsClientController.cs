using EventsManagement_Chayma.Models;
using EventsManagementAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace EventsManagementAppClient.Controllers
{
    public class ParticipantsClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllParticipants()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync(
                "api/Participants/get-all-participants"
                );
            if (response.IsSuccessStatusCode)
            {
                var participants = await response.Content.ReadFromJsonAsync<IEnumerable<ParticipantClient>>();
                return View(participants);
            }
            else
            {
                return View();
            }

        }

        public async Task<ActionResult> GetParticipantById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            HttpResponseMessage response = await client.GetAsync($"api/Participants/get-participant-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var participantDetail = await response.Content.ReadFromJsonAsync<ParticipantClient>();
                return View(participantDetail);
            }
            else
            {
                return View("Error");
            }
        }




        public async Task<ActionResult> CreateParticipant(ParticipantClient ParticipantClient)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Participants/create-participant", ParticipantClient);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("get-all-participants");
                }
                else 
                {
                    return View();
                }
            }
            return View(ParticipantClient);
        }

        // GET: Events/EditParticipant/{id}
        public async Task<ActionResult> EditParticipant(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Participants/edit-participant/{id}");
            if (response.IsSuccessStatusCode)
            {
                var participantDetail = await response.Content.ReadFromJsonAsync<ParticipantClient>();
                return View(participantDetail);
            }
            else
            {
                return View();
            }
        }

        // GET: Events/DeleteParticipant/{id}
        public async Task<ActionResult> DeleteParticipant(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Participants/delete-participant/{id}");
            if (response.IsSuccessStatusCode)
            {
                var participantDetail = await response.Content.ReadFromJsonAsync<ParticipantClient>();
                return View(participantDetail);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
