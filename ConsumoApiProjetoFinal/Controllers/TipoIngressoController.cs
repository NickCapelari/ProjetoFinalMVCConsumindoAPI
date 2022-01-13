using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ConsumoApiProjetoFinal.Controllers
{
   
    public class TipoIngressoController : Controller
    {
        private readonly TipoIngressoService _tipoIngressoService;

        public TipoIngressoController(TipoIngressoService tipoIngressoService)
        {
            _tipoIngressoService = tipoIngressoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var list = await _tipoIngressoService.GetAllAsync(tokenKey.ToString());
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _tipoIngressoService.GetByIdAsync(id, tokenKey.ToString());
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
        public async Task<IActionResult> Create(TipoIngresso tipoIngresso)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _tipoIngressoService.CreateAsync(tipoIngresso, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _tipoIngressoService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TipoIngresso tipoIngresso)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _tipoIngressoService.UpdateAsync(tipoIngresso, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _tipoIngressoService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _tipoIngressoService.DeleteAsync(id, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
