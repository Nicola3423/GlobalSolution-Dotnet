using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class PontuacaoQuizProfile : Profile
    {
        public PontuacaoQuizProfile()
        {
            CreateMap<PontuacaoQuiz, PontuacaoQuizDTO>();
            CreateMap<PontuacaoQuizDTO, PontuacaoQuiz>();
        }
    }
}
