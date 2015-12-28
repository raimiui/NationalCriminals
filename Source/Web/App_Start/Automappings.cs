using AutoMapper;
using Web.Models;
using Web.NationalCriminalsWebService;

namespace Web.App_Start
{
    public class Automappings : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PersonSearchViewModel, PersonSearchParametersDto>()
                .ForMember
                (
                    dest => dest.Sex, 
                    opts => opts.MapFrom
                        (
                            src => src.Sex.HasValue ? src.Sex.ToString() : null
                        )
                )
                .ForMember(dest => dest.ExtensionData, opts => opts.Ignore());

            base.Configure();
        }
    }
}