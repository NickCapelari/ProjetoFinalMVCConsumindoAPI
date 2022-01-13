using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ConsumoApiProjetoFinal.Controllers
{

    public class LocalEventoController : Controller
    {
        private readonly LocalEventoService _localEventoService;

        public LocalEventoController(LocalEventoService localEventoService)
        {
            _localEventoService = localEventoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var list = await _localEventoService.GetAllAsync(tokenKey.ToString());
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id) 
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _localEventoService.GetByIdAsync(id, tokenKey.ToString());
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
        public async Task<IActionResult> Create(LocalEvento localEvento)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _localEventoService.CreateAsync(localEvento, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _localEventoService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LocalEvento localEvento)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _localEventoService.UpdateAsync(localEvento,tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _localEventoService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _localEventoService.DeleteAsync(id, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
