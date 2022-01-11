using ConsumoApiProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;

namespace ConsumoApiProjetoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index2()
        {
            EventoService eventoService = new EventoService();
            var list = await eventoService.GetAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Index()
        {
            PortifolioService portifolioService = new PortifolioService();
            var list = await portifolioService.GetAllAsync();
            return View(list);
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