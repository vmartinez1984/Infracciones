using AutoMapper;
using Infracciones.Dto;
using Infracciones.Persistencia.Entity;
using System.Collections.Generic;

namespace Infracciones.Mappers
{
    public class BoletaDeSancionMapper
    {
        internal static List<BoletaDeSancion> GetAll(List<BoletaDeSancionEntity> entities)
        {
            IMapper mapper;
            List<BoletaDeSancion> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<BoletaDeSancion>>(entities);

            return lista;
        }

        internal static BoletaDeSancionEntity Get(BoletaDeSancion item)
        {
            IMapper mapper;
            BoletaDeSancionEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<BoletaDeSancionEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<BoletaDeSancionEntity, BoletaDeSancion>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<BoletaDeSancionEntity, BoletaDeSancion>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static BoletaDeSancion Get(BoletaDeSancionEntity entity)
        {
            IMapper mapper;
            BoletaDeSancion item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<BoletaDeSancion>(entity);

            return item;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<BoletaDeSancion, BoletaDeSancionEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
