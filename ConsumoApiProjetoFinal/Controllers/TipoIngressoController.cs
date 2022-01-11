﻿using ConsumoApiProjetoFinal.Models;
using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var list = await _tipoIngressoService.GetAllAsync();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _tipoIngressoService.GetByIdAsync(id);
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
            await _tipoIngressoService.CreateAsync(tipoIngresso);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _tipoIngressoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TipoIngresso tipoIngresso)
        {
            await _tipoIngressoService.UpdateAsync(tipoIngresso);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _tipoIngressoService.GetByIdAsync(id.Value);
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _tipoIngressoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
