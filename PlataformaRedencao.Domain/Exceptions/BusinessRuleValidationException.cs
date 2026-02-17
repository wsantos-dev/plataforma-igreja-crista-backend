namespace PlataformaRedencao.Domain.Exceptions
{
    public class BusinessRuleValidationException : DomainException
    {
        public BusinessRuleValidationException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}