using System;
using AutoMapper;

namespace DigitalApi
{
    public static class MapperInit
    {
        static MapperInit()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Use, Model.UsesDto>();

            });
        }
    }
}
