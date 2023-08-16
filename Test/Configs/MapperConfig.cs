using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Configs
{
    public static class MapperConfig
    {
        public static IMapper Get()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Api.Profiles.MappingProfile());
            });

            return mockMapper.CreateMapper();
        }
    }
}
