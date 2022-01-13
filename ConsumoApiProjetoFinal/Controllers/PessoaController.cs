using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ConsumoApiProjetoFinal.Controllers
{
    
    public class PessoaController : Controller
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var list = await _pessoaService.GetAllAsync(tokenKey.ToString());
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _pessoaService.GetByIdAsync(id, tokenKey.ToString());
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
        public async Task<IActionResult> Create(Pessoa pessoa, Contato contato)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _pessoaService.CreateAsync(pessoa, contato, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _pessoaService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Pessoa pessoa, Contato contato)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            ContatoService contatoService = new ContatoService();
            await contatoService.UpdateAsync(contato, tokenKey.ToString());
            await _pessoaService.UpdateAsync(pessoa, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            var obj = await _pessoaService.GetByIdAsync(id.Value, tokenKey.ToString());
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var tokenKey = JsonConvert.DeserializeObject(token);
            await _pessoaService.DeleteAsync(id, tokenKey.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
