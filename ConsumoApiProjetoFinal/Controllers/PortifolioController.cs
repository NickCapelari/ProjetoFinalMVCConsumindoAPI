using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var list = await _portifolioService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _portifolioService.GetByIdAsync(id);
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
            await _portifolioService.CreateAsync(portifolio);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _portifolioService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Portifolio portifolio)
        {
            await _portifolioService.UpdateAsync(portifolio);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _portifolioService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _portifolioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
