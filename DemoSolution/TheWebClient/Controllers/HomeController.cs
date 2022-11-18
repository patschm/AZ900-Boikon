using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TheWebClient.Models;

namespace TheWebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clients;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clients)
        {
            _logger = logger;
            _clients = clients;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var httpc = _clients.CreateClient("api");
            var result = await httpc.GetStringAsync("brand");
            var model = JsonConvert.DeserializeObject<List<BrandModel>>(result);
            return View(model);
        }

        public IActionResult Privacy(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}