using AutoMapper;
using SimpleAPI.Models;

namespace SimpleAPI
{
    public class SimpleMappingProfile : Profile
    {
        public SimpleMappingProfile()
        {
            CreateMap<Person, PersonDto>().ForMember(m => m.Occupation, c => c.MapFrom(s => s.Occupation.OccupationName));

            CreateMap<CreatePersonDto, Person>()
                .ForMember(r => r.Occupation,
                    c => c.MapFrom(dto => new Occupation()
                    { OccupationName = dto.Occupation}));
        }
    }
}
