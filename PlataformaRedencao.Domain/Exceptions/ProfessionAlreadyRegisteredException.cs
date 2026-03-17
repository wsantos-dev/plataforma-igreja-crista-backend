using PlataformaRedencao.Domain.Messages;

namespace PlataformaRedencao.Domain.Exceptions
{
    public class ProfessionAlreadyRegisteredException : DomainException
    {
        public ProfessionAlreadyRegisteredException()
            : base("PROFESSION_ALREADY_REGISTERED_EXCEPTION",
                    ErrorMessages.ProfessionalNotFound)
        {
        }
    }
}