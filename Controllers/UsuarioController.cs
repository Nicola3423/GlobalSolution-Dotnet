using Microsoft.AspNetCore.Mvc;
using Sessions_app.DTOs;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _service.GetAllAsync();
                if (usuarios == null) throw new Exception("Nenhum usuário encontrado.");
                return View(usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpGet("Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(UsuarioDTO usuarioDto)
        {
            if (!ModelState.IsValid) return View(usuarioDto);

            await _service.AddAsync(usuarioDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost("Editar/{id}")]
        public async Task<IActionResult> Edit(int id, UsuarioDTO usuarioDto)
        {
            if (!ModelState.IsValid) return View(usuarioDto);

            await _service.UpdateAsync(id, usuarioDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
