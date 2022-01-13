using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

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
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var list = await _ingressoService.GetAllAsync(tokenKey.ToString());
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _ingressoService.GetByIdAsync(id, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            TipoIngressoService tipoIngressoService = new TipoIngressoService();
            var tiposIngressos = await tipoIngressoService.GetAllAsync(tokenKey.ToString());

            EventoService eventoService = new EventoService();
            var eventos = await eventoService.GetByDateAsync();

            PessoaService pessoaService = new PessoaService();
            var pessoas = await pessoaService.GetAllAsync(tokenKey.ToString());

            var viewModel = new IngressoFormViewModel { TipoIngresso = tiposIngressos, Evento = eventos,  Pessoa = pessoas };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingresso ingresso)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _ingressoService.CreateAsync(ingresso, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _ingressoService.GetByIdAsync(id.Value, tokenKey.ToString());

            TipoIngressoService tipoIngressoService = new TipoIngressoService();
            var tiposIngressos = await tipoIngressoService.GetAllAsync(tokenKey.ToString());

            EventoService eventoService = new EventoService();
            var eventos = await eventoService.GetByDateAsync();

            PessoaService pessoaService = new PessoaService();
            var pessoas = await pessoaService.GetAllAsync(tokenKey.ToString());

            var viewModel = new IngressoFormViewModel { Ingresso = obj,Evento = eventos, TipoIngresso = tiposIngressos, Pessoa = pessoas };
            return View(viewModel);
            
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Ingresso ingresso)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _ingressoService.UpdateAsync(ingresso, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _ingressoService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _ingressoService.DeleteAsync(id, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
