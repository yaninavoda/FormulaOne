using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(dest => dest.Wins, options => options.MapFrom(src => src.RaceWins));
        }
    }
}
