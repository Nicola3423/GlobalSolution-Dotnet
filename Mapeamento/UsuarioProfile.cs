using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
