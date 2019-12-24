using AutoMapper;
using GameStorage.Domain.DTOs;
using GameStorage.Domain.Models;

namespace GameStorage.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TeamDTO, Team>();
            CreateMap<ConfigDTO, Config>();
            CreateMap<SetUpGameDTO, Game>();
        }
    }
}