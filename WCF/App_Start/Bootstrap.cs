﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;

namespace WCF.App_Start
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(x =>
            {
                var assembliesHavingAutomappings = new List<Assembly>
                {
                    typeof (Automappings).Assembly,
                    //typeof (ServicesAutomappingProfile).Assembly
                };

                var profileTypes = assembliesHavingAutomappings.SelectMany(
                    assembly => assembly.GetTypes().Where(type => type.IsSubclassOf(typeof (Profile)))
                    ).ToList();

                foreach (var profileType in profileTypes)
                        x.AddProfile((Profile)Activator.CreateInstance(profileType));

                Mapper.AssertConfigurationIsValid();
            });
        }
    }
}
