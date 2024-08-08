namespace Simple_C__Data_Access_with_Dapper_and_SQL.Exceptions
{
    public class ClientException : Exception
    {
        private ClientException() { }

        public ClientException(string message, ushort errorCode,
            int statusCode = StatusCodes.Status400BadRequest) : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public ushort ErrorCode { get; init; }
        public int StatusCode { get; init; }
    }
}
