namespace PlataformaRedencao.Application.Exceptions
{
    public abstract class ApplicationExceptionBase : Exception
    {
        public string ErrorCode { get; }

        protected ApplicationExceptionBase(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }



    }
}