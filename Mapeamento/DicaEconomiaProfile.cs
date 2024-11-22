using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class DicaEconomiaProfile : Profile
    {
        public DicaEconomiaProfile()
        {
            CreateMap<DicaEconomia, DicaEconomiaDTO>();
            CreateMap<DicaEconomiaDTO, DicaEconomia>();
        }
    }
}
