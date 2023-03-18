using Shared.Paging;

namespace eshop.Shared.Paging;
public static class IEnumerableExtensions
{
    public static PagedList<T> ToPageList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
