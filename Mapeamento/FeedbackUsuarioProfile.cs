using AutoMapper;
using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Mapeamento
{
    public class FeedbackUsuarioProfile: Profile
    {
        public FeedbackUsuarioProfile()
        {
            CreateMap<FeedbackUsuario, FeedbackUsuarioDTO>();
            CreateMap<FeedbackUsuarioDTO, FeedbackUsuario>();
        }
    }
}
