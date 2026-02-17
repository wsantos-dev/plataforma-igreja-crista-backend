using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.Application.Exceptions
{
    public class ConflictException : ApplicationExceptionBase
    {
        public ConflictException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}