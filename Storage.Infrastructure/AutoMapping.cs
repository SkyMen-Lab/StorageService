using AutoMapper;
using Storage.Domain.DTOs;
using Storage.Domain.Models;

namespace Storage.Infrastructure
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