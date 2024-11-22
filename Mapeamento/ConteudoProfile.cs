using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class ConteudoProfile : Profile
    {
        public ConteudoProfile()
        {
            CreateMap<Conteudo, ConteudoDTO>();
            CreateMap<ConteudoDTO, Conteudo>();
        }
    }
}
