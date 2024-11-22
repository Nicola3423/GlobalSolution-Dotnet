using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    [Route("Interacao")]
    public class InteracaoController : Controller
    {
        private readonly IInteracaoService _service;

        public InteracaoController(IInteracaoService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var interacoes = await _service.GetAllAsync();
            return View(interacoes);
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var interacao = await _service.GetByIdAsync(id);
            if (interacao == null) return NotFound();
            return View(interacao);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(InteracaoDTO interacaoDto)
        {
            if (!ModelState.IsValid) return View(interacaoDto);

            await _service.AddAsync(interacaoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var interacao = await _service.GetByIdAsync(id);
            if (interacao == null) return NotFound();
            return View(interacao);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, InteracaoDTO interacaoDto)
        {
            if (!ModelState.IsValid) return View(interacaoDto);

            await _service.UpdateAsync(id, interacaoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var interacao = await _service.GetByIdAsync(id);
            if (interacao == null) return NotFound();
            return View(interacao);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
