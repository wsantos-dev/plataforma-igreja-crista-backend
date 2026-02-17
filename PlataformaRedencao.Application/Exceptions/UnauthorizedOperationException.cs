using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.Application.Exceptions
{
    public class UnauthorizedOperationException : ApplicationExceptionBase
    {
        public UnauthorizedOperationException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}