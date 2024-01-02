using EventsManagementAppClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagementAppClient.Controllers
{
    public class CommentsClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllComments()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync(
                "api/Comments/get-all-comments"
                );
            if (response.IsSuccessStatusCode)
            {
                var participants = await response.Content.ReadFromJsonAsync<IEnumerable<CommentClient>>();
                return View(participants);
            }
            else
            {
                return View();
            }

        }

        public async Task<ActionResult> GetCommentById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            HttpResponseMessage response = await client.GetAsync("api/Comments/get-comment-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var commentDetail = await response.Content.ReadFromJsonAsync<IEnumerable<CommentClient>>();
                return View(commentDetail);
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> CreateComment(CommentClient commentClient)

        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Comments/create-comment", commentClient);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("get-all-comments");
                }
                else
                {
                    return View();
                }
            }
            return View(commentClient);
        }

        public async Task<ActionResult> EditComment(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Comments/edit-comment/{id}");
            if (response.IsSuccessStatusCode)
            {
                var commentDetail = await response.Content.ReadFromJsonAsync<CommentClient>();
                return View(commentDetail);
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteComment(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage response = await client.GetAsync($"api/Comments/delete-comment/{id}");
            if (response.IsSuccessStatusCode)
            {
                var commentDetail = await response.Content.ReadFromJsonAsync<CommentClient>();
                return View(commentDetail);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
