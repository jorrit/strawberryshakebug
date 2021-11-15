using Microsoft.AspNetCore.Mvc;
//using strawberryshakebug.Demo;

namespace strawberryshakebug
{
    public class HomeController : Controller
    {
        private readonly IConferenceClient _client;

        public HomeController(IConferenceClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _client.GetSessions.ExecuteAsync();

            result.EnsureNoErrors();

            return View(result.Data.Sessions);
        }
    }
}
