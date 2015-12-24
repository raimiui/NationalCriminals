using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models;
using WCF.Contracts;

namespace WCF.App_Start
{
    public class Automappings : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SexDto, Sex>();
            Mapper.CreateMap<PersonSearchParametersDto, PersonSearchParameters>();

            base.Configure();
        }
    }
}