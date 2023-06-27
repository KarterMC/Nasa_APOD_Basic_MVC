using Microsoft.AspNetCore.Mvc;
using NasaApodClient.Models;
using System.Diagnostics;

namespace NasaApodClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly NasaPicApiClient _client;

        public HomeController(NasaPicApiClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _client.Get();
                return View(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy()
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