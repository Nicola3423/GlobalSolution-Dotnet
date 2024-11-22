using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    [Route("PontuacaoQuiz")]
    public class PontuacaoQuizController : Controller
    {
        private readonly IPontuacaoQuizService _service;

        public PontuacaoQuizController(IPontuacaoQuizService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var pontuacoes = await _service.GetAllAsync();
            return View(pontuacoes);
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var pontuacao = await _service.GetByIdAsync(id);
            if (pontuacao == null) return NotFound();
            return View(pontuacao);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(PontuacaoQuizDTO pontuacaoDto)
        {
            if (!ModelState.IsValid) return View(pontuacaoDto);

            await _service.AddAsync(pontuacaoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pontuacao = await _service.GetByIdAsync(id);
            if (pontuacao == null) return NotFound();
            return View(pontuacao);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, PontuacaoQuizDTO pontuacaoDto)
        {
            if (!ModelState.IsValid) return View(pontuacaoDto);

            await _service.UpdateAsync(id, pontuacaoDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pontuacao = await _service.GetByIdAsync(id);
            if (pontuacao == null) return NotFound();
            return View(pontuacao);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
