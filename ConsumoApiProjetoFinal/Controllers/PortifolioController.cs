using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ConsumoApiProjetoFinal.Controllers
{
   
    public class PortifolioController : Controller
    {
        private readonly PortifolioService _portifolioService;
        public PortifolioController(PortifolioService portifolioService)
        {
            _portifolioService = portifolioService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var list = await _portifolioService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _portifolioService.GetByIdAsync(id, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portifolio portifolio)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _portifolioService.CreateAsync(portifolio, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _portifolioService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Portifolio portifolio)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _portifolioService.UpdateAsync(portifolio, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _portifolioService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _portifolioService.DeleteAsync(id, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
