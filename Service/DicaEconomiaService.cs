using AutoMapper;
using Sessions_app.DTOs;
using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace Sessions_app.Service
{
    public class DicaEconomiaService  : IDicaEconomiaService
    {
        private readonly IDicaEconomiaRepository _repository;
        private readonly IMapper _mapper;

        public DicaEconomiaService(IDicaEconomiaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DicaEconomiaDTO>> GetAllAsync()
        {
            var dicas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DicaEconomiaDTO>>(dicas);
        }

        public async Task<DicaEconomiaDTO> GetByIdAsync(int id)
        {
            var dica = await _repository.GetByIdAsync(id);
            if (dica == null)
                throw new KeyNotFoundException("Dica não encontrada.");
            return _mapper.Map<DicaEconomiaDTO>(dica);
        }

        public async Task AddAsync(DicaEconomiaDTO dicaEconomiaDto)
        {
            var dicaEconomia = _mapper.Map<DicaEconomia>(dicaEconomiaDto);
            await _repository.AddAsync(dicaEconomia);
        }

        public async Task UpdateAsync(int id, DicaEconomiaDTO dicaEconomiaDto)
        {
            var dica = await _repository.GetByIdAsync(id);
            if (dica == null)
                throw new KeyNotFoundException("Dica não encontrada.");

            _mapper.Map(dicaEconomiaDto, dica);
            await _repository.UpdateAsync(dica);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

