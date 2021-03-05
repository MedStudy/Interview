using System.Collections.Generic;

namespace AutoMapper
{
  public static class AutoMapperExtensions
  {
    public static List<T> MapList<T>(this IMapper mapper, object source)
    {
      return mapper.Map<List<T>>(source);
    }
  }
}
