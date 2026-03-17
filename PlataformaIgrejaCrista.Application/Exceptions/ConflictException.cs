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