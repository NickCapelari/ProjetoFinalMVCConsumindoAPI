using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var list = await _localEventoService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id) 
        {
            var obj = await _localEventoService.GetByIdAsync(id);
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
            await _localEventoService.CreateAsync(localEvento);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _localEventoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LocalEvento localEvento)
        {
            await _localEventoService.UpdateAsync(localEvento);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _localEventoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _localEventoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
