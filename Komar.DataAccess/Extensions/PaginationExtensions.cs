using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class PaginationExtensions
    {

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize)
        {
            return query.Skip(pageSize * page).Take(pageSize);
        }
    }
}
