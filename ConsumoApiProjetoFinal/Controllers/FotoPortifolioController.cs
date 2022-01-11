using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoApiProjetoFinal.Controllers
{
    
    public class FotoPortifolioController : Controller
    {
        private readonly FotoPortifolioService _fotoPortifolioService;

        public FotoPortifolioController(FotoPortifolioService fotoPortifolioService)
        {
            _fotoPortifolioService = fotoPortifolioService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _fotoPortifolioService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _fotoPortifolioService.GetByIdAsync(id);
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            PortifolioService _portifolioService = new PortifolioService();
            var portifolios = await _portifolioService.GetAllAsync();
            var viewModel = new FotoPortifolioViewModel { Portifolios = portifolios };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FotoPortifolio fotoPortifolio)
        {
            await _fotoPortifolioService.CreateAsync(fotoPortifolio);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            PortifolioService _portifolioService = new PortifolioService();
            var obj = await _fotoPortifolioService.GetByIdAsync(id.Value);
            List<Portifolio> portifolios = await _portifolioService.GetAllAsync();
            FotoPortifolioViewModel viewModel = new FotoPortifolioViewModel { FotoPortifolio = obj, Portifolios = portifolios };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FotoPortifolio fotoPortifolio)
        {
            await _fotoPortifolioService.UpdateAsync(fotoPortifolio);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _fotoPortifolioService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _fotoPortifolioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
