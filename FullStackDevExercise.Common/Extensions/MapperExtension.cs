using AutoMapper;
using FullStackDevExercise.Common.Interfaces;
using System.Collections.Generic;

namespace FullStackDevExercise.Common.Extensions
{
  public class MapperExtension : IMapperExtension
    {
        private readonly IMapper mapper;

        public MapperExtension(IMapper mapper)
        {
          this.mapper = mapper;
        }

        public TDestination MapObjectTo<TDestination>(object source)
        {
          TDestination t = mapper.Map<TDestination>(source);

          return t;
        }

        public List<TDestination> MapListTo<TDestination, TSource>(List<TSource> sourceList)
        {
          List<TDestination> destinationList = new List<TDestination>();
          sourceList.ForEach(x =>
          {
            TDestination source = MapObjectTo<TDestination>(x);
            destinationList.Add(source);
          });

          return destinationList;
        }

        public TDestination MapToExisting<TDestination, TSource>(TDestination destination, TSource source)
        {
          return mapper.Map(source, destination);
        }
    }
}
