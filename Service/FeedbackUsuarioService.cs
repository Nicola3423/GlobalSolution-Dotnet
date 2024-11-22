using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;
using SeuProjeto.Repositories;

namespace Sessions_app.Service
{
    public class FeedbackUsuarioService : IFeedbackUsuarioService
    {
        private readonly IFeedbackUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public FeedbackUsuarioService(IFeedbackUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackUsuarioDTO>> GetAllAsync()
        {
            var feedbacks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackUsuarioDTO>>(feedbacks);
        }

        public async Task<FeedbackUsuarioDTO> GetByIdAsync(int id)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null)
                throw new KeyNotFoundException("Feedback não encontrado.");
            return _mapper.Map<FeedbackUsuarioDTO>(feedback);
        }

        public async Task AddAsync(FeedbackUsuarioDTO feedbackUsuarioDto)
        {
            var feedbackUsuario = _mapper.Map<FeedbackUsuario>(feedbackUsuarioDto);
            await _repository.AddAsync(feedbackUsuario);
        }

        public async Task UpdateAsync(int id, FeedbackUsuarioDTO feedbackUsuarioDto)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null)
                throw new KeyNotFoundException("Feedback não encontrado.");

            _mapper.Map(feedbackUsuarioDto, feedback);
            await _repository.UpdateAsync(feedback);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
