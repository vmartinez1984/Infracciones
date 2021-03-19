using AutoMapper;
using Infracciones.Dto;
using Infracciones.Persistencia.Entity;
using System.Collections.Generic;

namespace Infracciones.Mappers
{
    internal class FraccionMapper
    {
        internal static List<Fraccion> GetAll(List<FraccionEntity> entities)
        {
            IMapper mapper;
            List<Fraccion> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<Fraccion>>(entities);

            return lista;
        }

        internal static FraccionEntity Get(Fraccion item)
        {
            IMapper mapper;
            FraccionEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<FraccionEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<FraccionEntity, Fraccion>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<FraccionEntity, Fraccion>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static Fraccion Get(FraccionEntity entity)
        {
            IMapper mapper;
            Fraccion item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<Fraccion>(entity);

            return item;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<Fraccion, FraccionEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
