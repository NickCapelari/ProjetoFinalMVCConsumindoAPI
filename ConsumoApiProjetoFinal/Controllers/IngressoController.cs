using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoApiProjetoFinal.Controllers
{
   
    public class IngressoController : Controller
    {
        private readonly IngressoService _ingressoService;

        public IngressoController(IngressoService ingressoService)
        {
            _ingressoService = ingressoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _ingressoService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _ingressoService.GetByIdAsync(id);
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            TipoIngressoService tipoIngressoService = new TipoIngressoService();
            var tiposIngressos = await tipoIngressoService.GetAllAsync();

            EventoService eventoService = new EventoService();
            var eventos = await eventoService.GetByDateAsync();

            PessoaService pessoaService = new PessoaService();
            var pessoas = await pessoaService.GetAllAsync();

            var viewModel = new IngressoFormViewModel { TipoIngresso = tiposIngressos, Evento = eventos,  Pessoa = pessoas };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingresso ingresso)
        {
            await _ingressoService.CreateAsync(ingresso);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            
            var obj = await _ingressoService.GetByIdAsync(id.Value);

            TipoIngressoService tipoIngressoService = new TipoIngressoService();
            var tiposIngressos = await tipoIngressoService.GetAllAsync();

            EventoService eventoService = new EventoService();
            var eventos = await eventoService.GetAllAsync();

            PessoaService pessoaService = new PessoaService();
            var pessoas = await pessoaService.GetAllAsync();

            var viewModel = new IngressoFormViewModel { Ingresso = obj,Evento = eventos, TipoIngresso = tiposIngressos, Pessoa = pessoas };
            return View(viewModel);
            
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Ingresso ingresso)
        {
            await _ingressoService.UpdateAsync(ingresso);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _ingressoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _ingressoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
