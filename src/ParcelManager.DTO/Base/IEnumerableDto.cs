using System.Collections.Generic;
using System.Linq;

namespace ParcelManager.DTO.Base
{
    public class IEnumerableDto<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
