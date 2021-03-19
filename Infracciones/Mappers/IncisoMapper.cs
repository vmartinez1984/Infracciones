using AutoMapper;
using Infracciones.Dto;
using Infracciones.Persistencia.Entity;
using System.Collections.Generic;

namespace Infracciones.Mappers
{
    internal class IncisoMapper
    {
        internal static List<Inciso> GetAll(List<IncisoEntity> entities)
        {
            IMapper mapper;
            List<Inciso> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<Inciso>>(entities);

            return lista;
        }

        internal static IncisoEntity Get(Inciso item)
        {
            IMapper mapper;
            IncisoEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<IncisoEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<IncisoEntity, Inciso>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<IncisoEntity, Inciso>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static Inciso Get(IncisoEntity entity)
        {
            IMapper mapper;
            Inciso item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<Inciso>(entity);

            return item;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<Inciso, IncisoEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}