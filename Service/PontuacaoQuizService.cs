using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;
using SeuProjeto.Repositories;

namespace Sessions_app.Service
{
    public class PontuacaoQuizService : IPontuacaoQuizService
    {
        private readonly IPontuacaoQuizRepository _repository;
        private readonly IMapper _mapper;

        public PontuacaoQuizService(IPontuacaoQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PontuacaoQuizDTO>> GetAllAsync()
        {
            var pontuacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PontuacaoQuizDTO>>(pontuacoes);
        }

        public async Task<PontuacaoQuizDTO> GetByIdAsync(int id)
        {
            var pontuacao = await _repository.GetByIdAsync(id);
            if (pontuacao == null)
                throw new KeyNotFoundException("Pontuação não encontrada.");
            return _mapper.Map<PontuacaoQuizDTO>(pontuacao);
        }

        public async Task AddAsync(PontuacaoQuizDTO pontuacaoQuizDto)
        {
            var pontuacaoQuiz = _mapper.Map<PontuacaoQuiz>(pontuacaoQuizDto);
            await _repository.AddAsync(pontuacaoQuiz);
        }

        public async Task UpdateAsync(int id, PontuacaoQuizDTO pontuacaoQuizDto)
        {
            var pontuacao = await _repository.GetByIdAsync(id);
            if (pontuacao == null)
                throw new KeyNotFoundException("Pontuação não encontrada.");

            _mapper.Map(pontuacaoQuizDto, pontuacao);
            await _repository.UpdateAsync(pontuacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
