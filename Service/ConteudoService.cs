using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;
using SeuProjeto.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeuProjeto.Services
{
    public class ConteudoService : IConteudoService
    {
        private readonly IConteudoRepository _repository;
        private readonly IMapper _mapper;

        public ConteudoService(IConteudoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConteudoDTO>> GetAllAsync()
        {
            var conteudos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConteudoDTO>>(conteudos);
        }

        public async Task<ConteudoDTO> GetByIdAsync(int id)
        {
            var conteudo = await _repository.GetByIdAsync(id);
            if (conteudo == null)
                throw new KeyNotFoundException("Conteúdo não encontrado.");
            return _mapper.Map<ConteudoDTO>(conteudo);
        }

        public async Task AddAsync(ConteudoDTO conteudoDto)
        {
            var conteudo = _mapper.Map<Conteudo>(conteudoDto);
            await _repository.AddAsync(conteudo);
        }

        public async Task UpdateAsync(int id, ConteudoDTO conteudoDto)
        {
            var conteudo = await _repository.GetByIdAsync(id);
            if (conteudo == null)
                throw new KeyNotFoundException("Conteúdo não encontrado.");

            _mapper.Map(conteudoDto, conteudo);
            await _repository.UpdateAsync(conteudo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
