using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    [Route("FeedbackUsuario")]
    public class FeedbackUsuarioController : Controller
    {
        private readonly IFeedbackUsuarioService _service;

        public FeedbackUsuarioController(IFeedbackUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _service.GetAllAsync();
            return View(feedbacks);
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(FeedbackUsuarioDTO feedbackDto)
        {
            if (!ModelState.IsValid) return View(feedbackDto);

            await _service.AddAsync(feedbackDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, FeedbackUsuarioDTO feedbackDto)
        {
            if (!ModelState.IsValid) return View(feedbackDto);

            await _service.UpdateAsync(id, feedbackDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
