namespace PlataformaRedencao.Domain.Exceptions
{
    public class ProfessionalNotFoundException : DomainException
    {
        public ProfessionalNotFoundException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}