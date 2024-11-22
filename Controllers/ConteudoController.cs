using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using SeuProjeto.Services;

namespace Sessions_app.Controllers
{
    [Route("Conteudo")]
    public class ConteudoController : Controller
    {
        private readonly IConteudoService _service;

        public ConteudoController(IConteudoService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var conteudos = await _service.GetAllAsync();
            return View(conteudos);
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var conteudo = await _service.GetByIdAsync(id);
            if (conteudo == null) return NotFound();
            return View(conteudo);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(ConteudoDTO conteudoDto)
        {
            if (!ModelState.IsValid) return View(conteudoDto);

            await _service.AddAsync(conteudoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var conteudo = await _service.GetByIdAsync(id);
            if (conteudo == null) return NotFound();
            return View(conteudo);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, ConteudoDTO conteudoDto)
        {
            if (!ModelState.IsValid) return View(conteudoDto);

            await _service.UpdateAsync(id, conteudoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var conteudo = await _service.GetByIdAsync(id);
            if (conteudo == null) return NotFound();
            return View(conteudo);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
