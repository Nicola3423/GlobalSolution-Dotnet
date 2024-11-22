using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    [Route("DicaEconomia")]
    public class DicaEconomiaController : Controller
    {
        private readonly IDicaEconomiaService _service;

        public DicaEconomiaController(IDicaEconomiaService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var dicas = await _service.GetAllAsync();
            return View(dicas);
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var dica = await _service.GetByIdAsync(id);
            if (dica == null) return NotFound();
            return View(dica);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(DicaEconomiaDTO dicaDto)
        {
            if (!ModelState.IsValid) return View(dicaDto);

            await _service.AddAsync(dicaDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dica = await _service.GetByIdAsync(id);
            if (dica == null) return NotFound();
            return View(dica);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, DicaEconomiaDTO dicaDto)
        {
            if (!ModelState.IsValid) return View(dicaDto);

            await _service.UpdateAsync(id, dicaDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dica = await _service.GetByIdAsync(id);
            if (dica == null) return NotFound();
            return View(dica);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
