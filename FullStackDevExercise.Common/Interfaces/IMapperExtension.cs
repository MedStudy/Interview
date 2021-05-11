using System.Collections.Generic;

namespace FullStackDevExercise.Common.Interfaces
{
    public interface IMapperExtension
    {
        TDestination MapObjectTo<TDestination>(object source);

        List<TDestination> MapListTo<TDestination, TSource>(List<TSource> sourceList);

        TDestination MapToExisting<TDestination, TSource>(TDestination destination, TSource source);
    }
}
