using System.Collections.Generic;
using System.Linq;

namespace ParcelManager.DTO.Base
{
    public class ErrorDto
    {
        public IEnumerable<string> ExceptionMessages { get; set; } = Enumerable.Empty<string>();
        public string? InnerExceptionMessage { get; set; }
    }
}
