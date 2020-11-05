using System.Collections.Generic;

namespace Komar.Shared.Dtos
{
    public class PaginationResultDto<T> where T: class
    {
        public PaginationResultDto(int count, List<T> items)
        {
            Count = count;
            Items = items;
        }

        public int Count { get; set; }
        public List<T> Items { get; set; }

    }
}
