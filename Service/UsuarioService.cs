using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;
using SeuProjeto.Repositories;

namespace Sessions_app.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task AddAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _repository.AddAsync(usuario);
        }

        public async Task UpdateAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            _mapper.Map(usuarioDto, usuario);
            await _repository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
