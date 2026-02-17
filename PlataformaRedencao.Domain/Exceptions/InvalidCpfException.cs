namespace PlataformaRedencao.Domain.Exceptions
{
    public class InvalidCpfException : DomainException
    {
        public InvalidCpfException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}