using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoApiProjetoFinal.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _pessoaService.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var obj = await _pessoaService.GetByIdAsync(id);
            return View(obj);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa, Contato contato)
        {

            await _pessoaService.CreateAsync(pessoa, contato);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            var obj = await _pessoaService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Pessoa pessoa, Contato contato)
        {
            ContatoService contatoService = new ContatoService();
            await contatoService.UpdateAsync(contato);
            await _pessoaService.UpdateAsync(pessoa);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _pessoaService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _pessoaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
