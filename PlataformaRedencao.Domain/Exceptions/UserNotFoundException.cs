using PlataformaRedencao.Domain.Messages;

namespace PlataformaRedencao.Domain.Exceptions
{
    public class InvalidUserOrPasswordException : DomainException
    {
        public InvalidUserOrPasswordException(string errorCode, string message)
            : base("INVALID_USER_OR_PASSWORD", ErrorMessages.InvalidUserOrPassword)
        {
        }
    }
}