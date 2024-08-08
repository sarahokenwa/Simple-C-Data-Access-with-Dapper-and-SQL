namespace Simple_C__Data_Access_with_Dapper_and_SQL.Exceptions
{
    public class PasswordVerificationException : Exception
    {
        public PasswordVerificationException(string message) : base(message) { }

        public PasswordVerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
