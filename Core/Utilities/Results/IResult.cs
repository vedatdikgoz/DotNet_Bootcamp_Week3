using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    
    public interface IResult
    {
        bool Success { get; } //get yazarsak sadece okunabilir demek.
        string Message { get; }

    }
}
