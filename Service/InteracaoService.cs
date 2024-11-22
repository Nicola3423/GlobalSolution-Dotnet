using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;
using SeuProjeto.Repositories;

namespace Sessions_app.Service
{
    public class InteracaoService : IInteracaoService
    {
        private readonly IInteracaoRepository _repository;
        private readonly IMapper _mapper;

        public InteracaoService(IInteracaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InteracaoDTO>> GetAllAsync()
        {
            var interacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InteracaoDTO>>(interacoes);
        }

        public async Task<InteracaoDTO> GetByIdAsync(int id)
        {
            var interacao = await _repository.GetByIdAsync(id);
            if (interacao == null)
                throw new KeyNotFoundException("Interação não encontrada.");
            return _mapper.Map<InteracaoDTO>(interacao);
        }

        public async Task AddAsync(InteracaoDTO interacaoDto)
        {
            var interacao = _mapper.Map<Interacao>(interacaoDto);
            await _repository.AddAsync(interacao);
        }

        public async Task UpdateAsync(int id, InteracaoDTO interacaoDto)
        {
            var interacao = await _repository.GetByIdAsync(id);
            if (interacao == null)
                throw new KeyNotFoundException("Interação não encontrada.");

            _mapper.Map(interacaoDto, interacao);
            await _repository.UpdateAsync(interacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
