using System;
using System.Collections.Generic;

namespace ParcelManager.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; set; }

        public ValidationException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
