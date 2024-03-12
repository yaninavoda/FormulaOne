﻿using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOne.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain() 
        {
            CreateMap<CreateDriverAchievementRequest, Achievement>()
                .ForMember(x => x.RaceWins, options => options.MapFrom(src => src.Wins))
                .ForMember(x => x.Status, options => options.MapFrom(src => 1))
                .ForMember(x => x.AddedDate, options => options.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UpdatedDate, options => options.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverAchievementRequest, Achievement>()
                .ForMember(x => x.RaceWins, options => options.MapFrom(src => src.Wins))
                .ForMember(x => x.UpdatedDate, options => options.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(dest => dest.Status, options => options.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, options => options.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, options => options.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(dest => dest.UpdatedDate, options => options.MapFrom(src => DateTime.UtcNow));
        }
    }
}
