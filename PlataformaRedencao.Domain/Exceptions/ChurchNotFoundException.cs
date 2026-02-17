using PlataformaRedencao.Domain.Messages;

namespace PlataformaRedencao.Domain.Exceptions
{
    public class ChurchNotFoundException : DomainException
    {
        public ChurchNotFoundException(string errorCode, string message)
            : base("CHURCH_NOT_FOUND", ErrorMessages.ChurchNotFound)
        {
        }
    }
}