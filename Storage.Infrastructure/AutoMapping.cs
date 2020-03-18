using System.Collections.Generic;
using System.Linq;
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
            CreateMap<GameUpdateDTO, Game>();
            CreateMap<TeamGameSummary, StartGameDTO.Team>()
                .ForMember(x => x.Code,
                    opt => opt.MapFrom(src => src.Team.Code))
                .ForMember(x => x.Name,
                    opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(x => x.NumberOfPlayers,
                    opt => opt.MapFrom(src => src.NumberOfPlayers))
                .ForMember(x => x.RouterIp,
                    opt => opt.MapFrom(src => src.Team.Config.RouterIpAddress));
            CreateMap<Game, StartGameDTO>()
                .ForMember(x => x.Duration,
                    opt => opt.MapFrom(x => x.DurationMinutes))
                .ForMember(x => x.Teams,
                    opt => opt.MapFrom(x => x.TeamGameSummaries));
            
            //TODO: Mapping from FinishedGameDTO to Game + TeamGameSummary
            CreateMap<FinishGameDTO.Team, TeamGameSummary>()
                .ForMember(x => x.NumberOfPlayers,
                    opt => opt.MapFrom(x => x.NumberOfPlayers))
                .ForMember(x => x.Score,
                    opt => opt.MapFrom(x => x.Score));

            CreateMap<FinishGameDTO, Game>()
                .ForMember(x => x.WinnerCode,
                    opt => opt.MapFrom(x => x.WinnerCode));
        }
    }
}