using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class InteracaoProfile : Profile
    {
        public InteracaoProfile()
        {
            CreateMap<Interacao, InteracaoDTO>();
            CreateMap<InteracaoDTO, Interacao>();
        }
    }
}
