using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.Application.Exceptions
{
    public class UseCaseValidationException : ApplicationExceptionBase
    {
        public UseCaseValidationException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}