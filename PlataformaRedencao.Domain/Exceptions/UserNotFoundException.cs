using PlataformaRedencao.Domain.Messages;

namespace PlataformaRedencao.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException()
            : base("USER_NOT_FOUND_EXCEPTION", ErrorMessages.UserNotFoundException)
        {
        }
    }
}