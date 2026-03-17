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