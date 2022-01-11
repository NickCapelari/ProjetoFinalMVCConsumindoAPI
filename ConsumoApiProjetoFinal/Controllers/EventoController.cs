using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoApiProjetoFinal.Controllers
{

    public class EventoController : Controller
    {
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _eventoService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _eventoService.GetByIdAsync(id);
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            LocalEventoService _localEventoService = new LocalEventoService();
            var locais = await _localEventoService.GetAllAsync();
            var viewModel = new EventoFormViewModel { LocalEventos = locais };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            await _eventoService.CreateAsync(evento);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            LocalEventoService _localEventoService = new LocalEventoService();
            var obj = await _eventoService.GetByIdAsync(id.Value);
            List<LocalEvento> locais = await _localEventoService.GetAllAsync();
            EventoFormViewModel viewModel = new EventoFormViewModel { Evento = obj, LocalEventos = locais };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Evento evento)
        {
            await _eventoService.UpdateAsync(evento);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _eventoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
